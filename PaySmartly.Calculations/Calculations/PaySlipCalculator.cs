using System.Runtime.CompilerServices;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Calculations
{
    public interface IPaySlipCalculator
    {
        PaySlip Calculate(PaySlipRequest paySlipRequest, TaxableIncomeTable taxableIncomeTable);
    }

    public class PaySlipCalculator(IFormulas formulas) : IPaySlipCalculator
    {
        private readonly IFormulas formulas = formulas;

        public PaySlip Calculate(PaySlipRequest paySlipRequest, TaxableIncomeTable taxableIncomeTable)
        {
            throw new NotImplementedException();
        }
    }
}