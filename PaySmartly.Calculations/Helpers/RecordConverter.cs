using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Helpers
{
    public static class RecordConverter
    {
        public static RecordDto ConvertToRecordDto(Record record)
        {
            // we can use AutoMapper but we will do it manually since we have only one mapping to a dto object 
            // that way we can start using AOT compilation
            return new(
                record.Id,
                record.Employee,
                record.AnnualSalary,
                record.SuperRate,
                record.PayPeriod,
                record.GrossIncome,
                record.IncomeTax,
                record.NetIncome,
                record.Super,
                record.Requester);
        }
    }
}