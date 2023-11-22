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
            double grossIncome = formulas.CalculateGrossIncome(paySlipRequest.AnnualSalary, paySlipRequest.Months, paySlipRequest.RoundTo);
            double incomeTax = formulas.CalculateIncomeTax(paySlipRequest.AnnualSalary, taxableIncomeTable, paySlipRequest.Months, paySlipRequest.RoundTo);
            double netIncome = formulas.CalculateNetIncome(grossIncome, incomeTax, paySlipRequest.RoundTo);
            double super = formulas.CalculateSuper(grossIncome, paySlipRequest.SuperRate, paySlipRequest.RoundTo);

            CalculatedPaySlip calculatedPaySlip = new(paySlipRequest, grossIncome, incomeTax, netIncome, super);
            return calculatedPaySlip;
        }
    }
}