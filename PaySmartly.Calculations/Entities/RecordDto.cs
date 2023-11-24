namespace PaySmartly.Calculations.Entities
{
    public record class RecordDto(
            string Id,
            EmployeeIdentity Employee,
            double AnnualSalary,
            double SuperRate,
            string PayPeriod,
            double GrossIncome,
            double IncomeTax,
            double NetIncome,
            double Super,
            RequesterIdentity Requester);
}