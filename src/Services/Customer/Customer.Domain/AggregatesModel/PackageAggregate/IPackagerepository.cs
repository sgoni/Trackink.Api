using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.PackageAggregate
{
    public interface IPackageRepository : IRepository<Package>
    {
        Task<Package> GetPackageAggregateEntity(string trackingNo);
    }
}
