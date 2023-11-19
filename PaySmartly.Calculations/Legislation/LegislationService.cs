using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislationService
    {
        // TODO: return service identity with each and every call
        Task<TaxableIncomeTable> GetTaxableIncomeTable();
        Task<bool> IsValidIRD(IRD ird);
    }

    public class LegislationService : ILegislationService
    {
        public Task<ServiceIdentity> GetIdentity()
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