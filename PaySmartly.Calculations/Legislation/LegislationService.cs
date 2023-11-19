using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislationService
    {
        Task<TaxableIncomeTable> GetTaxableIncomeTable();
        Task<bool> IsValidIRD(IRD ird);
    }

    public class LegislationService : ILegislationService
    {
        public Task<LegislationServiceIdentity> GetIdentity()
        {
            throw new NotImplementedException();
        }

        public Task<TaxableIncomeTable> GetTaxableIncomeTable()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidIRD(IRD ird)
        {
            throw new NotImplementedException();
        }
    }
}