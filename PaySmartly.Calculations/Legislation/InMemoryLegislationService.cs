using System.Collections.ObjectModel;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public class InMemoryLegislationService : ILegislationService
    {
        private readonly TaxableIncomeTable taxableIncomeTable;

        public InMemoryLegislationService()
        {
            TaxableRange range1 = new(0, 14_000);
            TaxableRange range2 = new(14_001, 48_000);
            TaxableRange range3 = new(48_001, 70_000);
            TaxableRange range4 = new(70_001, 180_000);
            TaxableRange range5 = new(180_001, int.MaxValue);

            ReadOnlyCollection<TaxableRange> readOnlyRanges = new([range1, range2, range3, range4, range5]);
            taxableIncomeTable = new(readOnlyRanges);
        }

        public ServiceIdentity Identity { get; } = new("0.1.0.0");

        public Task<ServiceResult<TaxableIncomeTable>> GetTaxableIncomeTable(string month)
        {
            ServiceResult<TaxableIncomeTable> result = new(taxableIncomeTable, Identity);
            return Task.FromResult(result);
        }

        public Task<ServiceResult<bool>> IsValidIRD(IRD ird) => Task.FromException<ServiceResult<bool>>(new NotImplementedException());
    }
}