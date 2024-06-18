using Customer.Domain.AggregatesModel.CustomerAggregate;
using SharedKernel.SeedWork;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Client>, ICustomerRepository
    {
        public CustomerRepository(CustomerDBContext context) : base(context) { }

        public CustomerDBContext CustomerTypeContext
        {
            get { return _context as CustomerDBContext; }
        }
    }
}
