using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislationService
    {
        // TODO: return service identity with each and every call
        Task<ServiceResult<TaxableIncomeTable>> GetTaxableIncomeTable();
        Task<ServiceResult<bool>> IsValidIRD(IRD ird);
    }

    public class LegislationService : ILegislationService
    {

        public Task<ServiceResult<TaxableIncomeTable>> GetTaxableIncomeTable()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> IsValidIRD(IRD ird)
        {
            throw new NotImplementedException();
        }
    }
}