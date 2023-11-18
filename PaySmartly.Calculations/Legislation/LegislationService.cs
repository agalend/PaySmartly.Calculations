using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislationService
    {
        Task<TaxableIncomeTable> GetTaxableIncomeTable();
        Task<bool> IsValidIRD(string ird);
    }

    public class LegislationService : ILegislationService
    {
        public Task<TaxableIncomeTable> GetTaxableIncomeTable()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidIRD(string ird)
        {
            throw new NotImplementedException();
        }
    }
}