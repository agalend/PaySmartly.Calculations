using System.Text;
using PaySmartly.Calculations.Entities;
using System.Linq;

namespace PaySmartly.Calculations.Calculations
{
    public interface IFormulas
    {
        double CalculateGrossIncome(double annualSalary, double months, int roundTo);
        double CalculateIncomeTax(double annualSalary, TaxableIncomeTable table, double months, int roundTo);
        double CalculateNetIncome(double grossIncome, double incomeTax, int roundTo);
        double CalculateSuper(double grossIncome, double superRate, int roundTo);
    }

    public class Formulas : IFormulas
    {
        public double CalculateGrossIncome(double annualSalary, double months, int roundTo)
        {
            double grossIncome = annualSalary / months;

            return Math.Round(grossIncome, roundTo);
        }

        public double CalculateIncomeTax(double annualSalary, TaxableIncomeTable table, double months, int roundTo)
        {
            StringBuilder stringBuilder = new();
            TaxableRange[] ranges = [.. table.Ranges];

            double incomeTax = 0d;

            for (int i = 0; i < ranges.Length; i++)
            {
                TaxableRange range = ranges[i];

                bool isInTheRange = range.Start <= annualSalary && annualSalary <= range.End;
                if (!isInTheRange)
                {
                    incomeTax += Math.Round((range.End - range.Start) * range.Tax);
                }
                else
                {
                    incomeTax += Math.Round((annualSalary - range.Start) * range.Tax);
                    incomeTax /= months;
                    break;
                }
            }

            return Math.Round(incomeTax, roundTo);
        }

        public double CalculateNetIncome(double grossIncome, double incomeTax, int roundTo)
        {
            double netIncome = grossIncome - incomeTax;

            return Math.Round(netIncome, roundTo);
        }

        public double CalculateSuper(double grossIncome, double superRate, int roundTo)
        {
            double super = (superRate / 100) * grossIncome;

            return Math.Round(super, roundTo);
        }
    }
}