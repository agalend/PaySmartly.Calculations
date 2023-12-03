using System.Collections.ObjectModel;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;

namespace PaySmartly.Calculations.Tests
{
    public class InMemoryLegislationService : ILegislation
    {
        private readonly TaxableIncomeTable taxableIncomeTable;

        public InMemoryLegislationService()
        {
            TaxableRange range1 = new(0, 14_000, 0.105);
            TaxableRange range2 = new(14_001, 48_000, 0.175);
            TaxableRange range3 = new(48_001, 70_000, 0.3);
            TaxableRange range4 = new(70_001, 180_000, 0.33);
            TaxableRange range5 = new(180_001, double.MaxValue, 0.39);

            ReadOnlyCollection<TaxableRange> ranges = new([range1, range2, range3, range4, range5]);
            taxableIncomeTable = new(ranges);
        }

        public Task<TaxableIncomeTable> GetTaxableIncomeTable(DateTime payPeriodFrom, DateTime payPeriodTo)
        {
            return Task.FromResult(taxableIncomeTable);
        }

        public Task<bool> IsValidIRD(IRD ird)
        {
            return Task.FromException<bool>(new NotImplementedException());
        }
    }
}