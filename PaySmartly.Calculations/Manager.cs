using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations
{
    public interface IManager
    {
        Task<PaySlipRecord?> CreatePaySlip(PaySlipRequest request);
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
    }
}