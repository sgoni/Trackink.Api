using Microsoft.EntityFrameworkCore;
using SharedKernel.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Domain.AggregatesModel.CustomerAggregate
{
    [Keyless]
    [NotMapped]
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public string PlusCode { get; private set; }

        public Address() { }

        public Address(string street, string zipCode, double longitude, double latitude, string plusCode)
        : this()
        {
            Street = street;
            ZipCode = zipCode;
            Longitude = longitude;
            Latitude = latitude;
            PlusCode = plusCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return ZipCode;
            yield return Longitude;
            yield return Latitude;
            yield return PlusCode;
        }
    }
}
