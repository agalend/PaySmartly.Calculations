namespace PaySmartly.Calculations.Entities
{
    public record class PaySlipRecordDto(
            string Id,
            EmployeeIdentity Employee,
            double AnnualSalary,
            double SuperRate,
            string PayPeriod,
            ResultWithFormula<double> GrossIncome,
            ResultWithFormula<double> IncomeTax,
            ResultWithFormula<double> NetIncome,
            ResultWithFormula<double> Super,
            RequesterIdentity Requester);
}