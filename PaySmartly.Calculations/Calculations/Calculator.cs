using System.Runtime.CompilerServices;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Calculations
{
    public interface ICalculator
    {
        PaySlip Calculate(PaySlipRequest request, TaxableIncomeTable taxableIncomeTable);
    }

    public class Calculator(IFormulas formulas) : ICalculator
    {
        private readonly IFormulas formulas = formulas;

        public PaySlip Calculate(PaySlipRequest request, TaxableIncomeTable taxableIncomeTable)
        {
            double grossIncome = formulas.CalculateGrossIncome(request.AnnualSalary, request.Months, request.RoundTo);
            double incomeTax = formulas.CalculateIncomeTax(request.AnnualSalary, taxableIncomeTable, request.Months, request.RoundTo);
            double super = formulas.CalculateSuper(grossIncome, request.SuperRate, request.RoundTo);
            double netIncome = formulas.CalculateNetIncome(grossIncome, incomeTax, super, request.RoundTo);

            PaySlip paySlip = new(request, grossIncome, incomeTax, netIncome, super, DateTime.UtcNow);
            return paySlip;
        }
    }
}