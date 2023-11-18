using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Calculations
{
    public interface IFormulas
    {
        ResultWithFormula<double> CalculateGrossIncome(double annualSalary, double months);
        ResultWithFormula<double> CalculateIncomeTax(double annualSalary, TaxableIncomeTable table);
        ResultWithFormula<double> CalculateNetIncome(double grossIncome, double incomeTax);
        ResultWithFormula<double> CalculateSuper(double grossIncome, double superRate);
    }

    public class Formulas : IFormulas
    {
        public ResultWithFormula<double> CalculateGrossIncome(double annualSalary, double months)
        {
            // AnnualSalary / 12, double check in pdf
            throw new NotImplementedException();
        }

        public ResultWithFormula<double> CalculateIncomeTax(double annualSalary, TaxableIncomeTable table)
        {
            // based on TaxableIncome, see pdf and online
            throw new NotImplementedException();
        }

        public ResultWithFormula<double> CalculateNetIncome(double grossIncome, double incomeTax)
        {
            // GrossIncome - IncomeTax, double check in pdf
            throw new NotImplementedException();
        }

        public ResultWithFormula<double> CalculateSuper(double grossIncome, double superRate)
        {
            // GrossIncome * SuperRate, double check in pdf
            throw new NotImplementedException();
        }
    }
}