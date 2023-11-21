using System.Runtime.CompilerServices;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Calculations
{
    public interface IPaySlipCalculator
    {
        CalculatedPaySlip Calculate(PaySlipRequest paySlipRequest, TaxableIncomeTable taxableIncomeTable);
    }

    public class PaySlipCalculator(IFormulas formulas) : IPaySlipCalculator
    {
        private readonly IFormulas formulas = formulas;

        public CalculatedPaySlip Calculate(PaySlipRequest paySlipRequest, TaxableIncomeTable taxableIncomeTable)
        {
            throw new NotImplementedException();
        }
    }
}