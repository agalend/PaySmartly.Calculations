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
            double grossIncome = annualSalary / months;

            string formula = $"{nameof(grossIncome)} = {nameof(annualSalary)} / {nameof(months)}";

            return new(grossIncome, formula);
        }

        public ResultWithFormula<double> CalculateIncomeTax(double annualSalary, TaxableIncomeTable table)
        {
            // based on TaxableIncome, see pdf and online
            throw new NotImplementedException();
        }

        public ResultWithFormula<double> CalculateNetIncome(double grossIncome, double incomeTax)
        {
            double netIncome = grossIncome - incomeTax;

            string formula = $"{nameof(netIncome)} = {nameof(grossIncome)} - {nameof(incomeTax)}";

            return new(netIncome, formula);
        }

        public ResultWithFormula<double> CalculateSuper(double grossIncome, double superRate)
        {
            double super = grossIncome * superRate;

            string formula = $"{nameof(super)} = {nameof(grossIncome)} * {nameof(superRate)}";

            return new(super, formula);
        }
    }
}