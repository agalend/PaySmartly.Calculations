namespace PaySmartly.Calculations.Entities
{
    public record class PaySlip(
                IRD IRD,
                EmployeeIdentity Employee,
                double AnnualSalary,
                double SuperRate,
                string PayPeriod);
}