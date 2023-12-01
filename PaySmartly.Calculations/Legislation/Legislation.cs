using Google.Protobuf.WellKnownTypes;
using PaySmartly.Calculations.Entities;
using PaySmartly.Legislation;
using static PaySmartly.Legislation.Legislation;
using static PaySmartly.Calculations.Helpers.PaySlipConverter;

namespace PaySmartly.Calculations.Legislation
{
    public interface ILegislation
    {
        Task<Entities.TaxableIncomeTable> GetTaxableIncomeTable(DateTime payPeriodFrom, DateTime payPeriodTo);
        Task<bool> IsValidIRD(IRD ird);
    }

    public class Legislation(LegislationClient client) : ILegislation
    {
        private readonly LegislationClient client = client;

        public async Task<Entities.TaxableIncomeTable> GetTaxableIncomeTable(DateTime payPeriodFrom, DateTime payPeriodTo)
        {
            Request request = new()
            {
                PayPeriodFrom = Timestamp.FromDateTime(payPeriodFrom.ToUniversalTime()),
                PayPeriodTo = Timestamp.FromDateTime(payPeriodTo.ToUniversalTime())
            };
            
            Response response = await client.GetTableAsync(request);

            Entities.TaxableIncomeTable table = Convert(response.Table);

            return table;
        }

        public Task<bool> IsValidIRD(IRD ird)
        {
            throw new NotImplementedException();
        }
    }
}