namespace PaySmartly.Calculations.Entities
{
    public record class PaySlipRequest(
                EmployeeIdentity Employee,
                double AnnualSalary,
                double SuperRate,
                string PayPeriod,
                RequesterIdentity Requester);
}