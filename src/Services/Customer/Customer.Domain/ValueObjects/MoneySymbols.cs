using Customer.Domain.Enums;

namespace Customer.Domain.ValueObjects
{
    public static class MoneySymbols
    {
        private static Dictionary<MoneyUnit, string> _symbols;

        static MoneySymbols()
        {
            if (_symbols != null)
                return;

            _symbols = new Dictionary<MoneyUnit, string>
            {
                { MoneyUnit.UnSpecified, string.Empty },

                { MoneyUnit.Dollar, "$" },

                { MoneyUnit.Euro, "€" },

                { MoneyUnit.Colones, "₡" },
            };
        }

        public static string GetSymbol(MoneyUnit moneyUnit)
        {
            return _symbols[moneyUnit].ToString();
        }
    }
}
