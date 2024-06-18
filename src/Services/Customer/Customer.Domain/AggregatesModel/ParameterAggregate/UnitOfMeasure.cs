using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.ParameterAggregate
{
    public class UnitOfMeasure : Entity, IAggregateRoot
    {
        private string _name;
        private string _symbol;
        private string _description;
        private string _type;
        private int _default;

        public string Name { get; set; }

        public string Symbol { get; set; }

        public UnitOfMeasure() { }

        public UnitOfMeasure(string name, string symbol, string type, int defaultVal)
            : this()
        {
            _name = name;
            _symbol = symbol;
            _type = type;
            _default = defaultVal;
        }

        public void SetName(string value)
        {
            _name = value;
        }

        public void SetSymbol(string value)
        {
            _symbol = value;
        }
        public void SetType(string value)
        {
            _type = value;
        }

        public void SetDefault(int value)
        {
            _default = value;
        }
    }
}
