namespace PaySmartly.Calculations.Entities
{
    public record class PaySlipRecordDto(
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