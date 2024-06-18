using Customer.Domain.AggregatesModel.CustomerAggregate;
using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.ParameterAggregate
{
    public class Parameter : Entity, IAggregateRoot
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// One to one relationship
        /// </summary>
        public ICollection<Client> Customers { get; set; }

        public Parameter() { }

        public Parameter(string category, string description, string name) : this()
        {
            Category = category;
            Description = description;
            Name = name;
        }
    }
}
