using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations
{
    public interface IManager
    {
        Task<PaySlipRecord?> CreatePaySlip(PaySlipRequest request);
        Task<PaySlipRecord?> GetPaySlip(string recordId);
        Task<PaySlipRecord?> DeletePaySlip(string recordId);
    }

    public class Manager(
        IPersistance persistance,
        ILegislation legislation,
        ICalculator calculator) : IManager
    {
        private readonly IPersistance persistance = persistance;
        private readonly ILegislation legislation = legislation;
        private readonly ICalculator calculator = calculator;

        public async Task<PaySlipRecord?> CreatePaySlip(PaySlipRequest request)
        {
            TaxableIncomeTable table = await legislation.GetTaxableIncomeTable(request.PayPeriod);

            PaySlip paySlip = calculator.Calculate(request, table);

            PaySlipRecord? record = await persistance.Create(paySlip);

            return record;
        }

        public async Task<PaySlipRecord?> GetPaySlip(string recordId)
        {
            PaySlipRecord? record = await persistance.Get(recordId);
            return record;
        }

        public async Task<PaySlipRecord?> DeletePaySlip(string recordId)
        {
            PaySlipRecord? record = await persistance.Delete(recordId);
            return record;
        }
    }
}