namespace PaySmartly.Calculations.Entities
{
    public record class UserRequest(
                EmployeeIdentity Employee,
                double AnnualSalary,
                double SuperRate,
                string PayPeriod,
                int RoundTo,
                int Months,
                RequesterIdentity Requester);
}