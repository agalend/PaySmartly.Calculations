using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Helpers
{
    public static class PaySlipConverter
    {
        public static PaySlipRecordDto ConvertToPlaySlipRecordDto(PaySlipRecord record)
        {
            // we can use AutoMapper but we will do it manually 
            // since we have only one mapping to a dto object 
            // that way we are going to save memory if AOT compilation is used
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

        public static PaySlipCreateRecordRequest ConvertToPlaySlipCreateRecordRequest(
            CalculatedPaySlip calculated,
            ServiceIdentity calculationsService,
            ServiceIdentity legislationService)
        {
            return new(
                calculated,
                calculationsService,
                legislationService);
        }
    }
}