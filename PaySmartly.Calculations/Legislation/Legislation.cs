using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislation
    {
        Task<TaxableIncomeTable> GetTaxableIncomeTable(DateTime period);
        Task<bool> IsValidIRD(IRD ird);
    }

    public class Legislation : ILegislation
    {

        public Task<TaxableIncomeTable> GetTaxableIncomeTable(DateTime period)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidIRD(IRD ird)
        {
            throw new NotImplementedException();
        }
    }
}