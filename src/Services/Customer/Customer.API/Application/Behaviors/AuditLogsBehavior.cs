using Audit.Core;
using MediatR;
using System.Reflection;

namespace Customer.API.Application.Behaviors
{
    public class AuditLogsBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<AuditLogsBehavior<TRequest, TResponse>> _logger;
        private readonly IConfiguration _config;

        public AuditLogsBehavior(
            ICurrentUserService currentUserService,
            ILogger<AuditLogsBehavior<TRequest, TResponse>> logger,
            IConfiguration config)
        {
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("User {@User} with request {@Request}", _currentUserService.User, request);

            IAuditScope? scope = null;

            // The current IRequest arrives with the [AuditLog] attribute
            var auditLogAttributes = request.GetType().GetCustomAttributes<AuditLogAttribute>();

            // if it contains an [AuditLog] we proceed to use the methods Audit.NET provides us to audit the operation.
            if (auditLogAttributes.Any() && _config.GetValue<bool>("AuditLogs:Enabled"))
            {
                // The IRequest has the [AuditLog] attribute to be audited. We create an Audit.NET scope.
                scope = AuditScope.Create(_ => _
                    .EventType(typeof(TRequest).Name)
                    .ExtraFields(new
                    {
                        _currentUserService.User,
                        Request = request
                    }));
            }

            var result = await next();

            if (scope is not null)
            {
                await scope.DisposeAsync();
            }

            return result;
        }
    }
}
