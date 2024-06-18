using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.PackageAggregate
{
    public class Package : Entity, IAggregateRoot
    {
        private float _weight;
        private string _dimensions;
        private string _content;
        private DateTime _date;
        private decimal _worth;
        private string _currency;

        public Package() { }

        public Package(string tracking, float weight, string dimensions, string content, DateTime date, decimal worth, string currency) : this()
        {
            Tracking = tracking;
            _weight = weight;
            _dimensions = dimensions;
            _content = content;
            _date = date;
            _worth = worth;
            _currency = currency;
        }

        public string Tracking { get; private set; }

        public int UnitMeasurementId { get; private set; }

        public void SetWeight(float value)
        {
            _weight = value;
        }

        public void SetDimensionst(string value)
        {
            _dimensions = value;
        }

        public void SetContent(string value)
        {
            _content = value;
        }

        public void SetDate(DateTime value)
        {
            _date = value;
        }

        public void SetWorth(decimal value)
        {
            _worth = value;
        }

        public void SetCurrency(string value)
        {
            _currency = value;
        }
    }
}
