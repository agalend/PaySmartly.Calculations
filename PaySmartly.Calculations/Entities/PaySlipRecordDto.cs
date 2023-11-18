namespace PaySmartly.Calculations.Entities
{
    public record class PaySlipRecordDto(
            string Id,
            string IRD,
            string FirstName,
            string LastName,
            double AnnualSalary,
            double SuperRate,
            string PayPeriod,
            ResultWithFormula<double> GrossIncome,
            ResultWithFormula<double> IncomeTax,
            ResultWithFormula<double> NetIncome,
            ResultWithFormula<double> Super,
            DateTime TransactionTime,
            string Requester);
}