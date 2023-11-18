using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislationService
    {
        string Identity { get; }

        Task<TaxableIncomeTable> GetTaxableIncomeTable();
        Task<bool> IsValidIRD(IRD ird);
    }

    public class LegislationService : ILegislationService
    {
        public string Identity => "version 1";

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