using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.AddressAggregate
{
    public class AddressValueObject : ValueObject
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public AddressValueObject() { }

        public AddressValueObject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Id;
            yield return Name;
        }
    }
}
