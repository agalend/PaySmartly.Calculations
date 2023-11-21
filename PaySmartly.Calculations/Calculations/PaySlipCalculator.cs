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
            double grossIncome = formulas.CalculateGrossIncome(paySlipRequest.AnnualSalary, months: 12);
            double incomeTax = formulas.CalculateIncomeTax(paySlipRequest.AnnualSalary, taxableIncomeTable, months: 12);
            double netIncome = formulas.CalculateNetIncome(grossIncome, incomeTax);
            double super = formulas.CalculateSuper(grossIncome, paySlipRequest.SuperRate);

            CalculatedPaySlip calculatedPaySlip = new(paySlipRequest, grossIncome, incomeTax, netIncome, super);
            return calculatedPaySlip;
        }
    }
}