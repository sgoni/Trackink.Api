using Customer.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Infrastructure.Builder
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddDefaultDbContext(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<CustomerDBContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return builder;
        }
    }
}
