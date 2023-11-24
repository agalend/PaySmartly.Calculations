using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislation
    {
        Task<TaxableIncomeTable> GetTaxableIncomeTable(string month);
        Task<bool> IsValidIRD(IRD ird);
    }

    public class Legislation : ILegislation
    {

        public Task<TaxableIncomeTable> GetTaxableIncomeTable(string month)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidIRD(IRD ird)
        {
            throw new NotImplementedException();
        }
    }
}