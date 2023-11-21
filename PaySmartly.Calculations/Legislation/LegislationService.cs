using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislationService
    {
        Task<ServiceResult<TaxableIncomeTable>> GetTaxableIncomeTable(string month);
        Task<ServiceResult<bool>> IsValidIRD(IRD ird);
    }

    public class LegislationService : ILegislationService
    {

        public Task<ServiceResult<TaxableIncomeTable>> GetTaxableIncomeTable(string month)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> IsValidIRD(IRD ird)
        {
            throw new NotImplementedException();
        }
    }
}