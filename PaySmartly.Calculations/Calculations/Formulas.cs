using System.Text;
using PaySmartly.Calculations.Entities;
using System.Linq;

namespace PaySmartly.Calculations.Calculations
{
    public interface IFormulas
    {
        double CalculateGrossIncome(double annualSalary, double months);
        double CalculateIncomeTax(double annualSalary, TaxableIncomeTable table, double months);
        double CalculateNetIncome(double grossIncome, double incomeTax);
        double CalculateSuper(double grossIncome, double superRate);
    }

    public class Formulas : IFormulas
    {
        public double CalculateGrossIncome(double annualSalary, double months)
        {
            double grossIncome = annualSalary / months;

            return Math.Round(grossIncome, 2);
        }

        public double CalculateIncomeTax(double annualSalary, TaxableIncomeTable table, double months)
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

            return Math.Round(incomeTax, 2);
        }

        public double CalculateNetIncome(double grossIncome, double incomeTax)
        {
            double netIncome = grossIncome - incomeTax;

            return Math.Round(netIncome, 2);
        }

        public double CalculateSuper(double grossIncome, double superRate)
        {
            double super = (superRate / 100) * grossIncome;

            return Math.Round(super, 2);
        }
    }
}