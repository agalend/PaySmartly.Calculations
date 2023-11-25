using System.Runtime.CompilerServices;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Calculations
{
    public interface ICalculator
    {
        PaySlip Calculate(UserRequest request, TaxableIncomeTable taxableIncomeTable);
    }

    public class Calculator(IFormulas formulas) : ICalculator
    {
        private readonly IFormulas formulas = formulas;

        public PaySlip Calculate(UserRequest request, TaxableIncomeTable taxableIncomeTable)
        {
            double grossIncome = formulas.CalculateGrossIncome(request.AnnualSalary, request.Months, request.RoundTo);
            double incomeTax = formulas.CalculateIncomeTax(request.AnnualSalary, taxableIncomeTable, request.Months, request.RoundTo);
            double netIncome = formulas.CalculateNetIncome(grossIncome, incomeTax, request.RoundTo);
            double super = formulas.CalculateSuper(grossIncome, request.SuperRate, request.RoundTo);

            PaySlip paySlip = new(request, grossIncome, incomeTax, netIncome, super);
            return paySlip;
        }
    }
}