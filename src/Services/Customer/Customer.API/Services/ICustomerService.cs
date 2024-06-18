using Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Customer.API.Services
{
    public interface ICustomerService
    {
        Task<bool> Delete(int id);

        Task<IList<Client>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Client?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Client?> GetByDNIAsync(string dni, CancellationToken cancellationToken = default);

        Task<Client> Create(Client customer);

        Task<Client> Update(Client customer);
    }
}
