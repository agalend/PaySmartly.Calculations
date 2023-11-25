using PaySmartly.Calculations.HATEOAS;

namespace PaySmartly.Calculations.Entities
{
    public record class PaySlipResponse(
            string Id,
            EmployeeIdentity Employee,
            double AnnualSalary,
            double SuperRate,
            string PayPeriod,
            double GrossIncome,
            double IncomeTax,
            double NetIncome,
            double Super,
            RequesterIdentity Requester,
            IEnumerable<Link> Links);
}