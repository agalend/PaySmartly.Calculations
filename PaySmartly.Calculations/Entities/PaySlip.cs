namespace PaySmartly.Calculations.Entities
{
    public record class PaySlip(
                string IRD,
                string FirstName,
                string LastName,
                double AnnualSalary,
                double SuperRate,
                string PayPeriod);
}