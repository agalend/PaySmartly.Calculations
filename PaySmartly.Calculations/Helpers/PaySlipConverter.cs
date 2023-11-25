using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.HATEOAS;

namespace PaySmartly.Calculations.Helpers
{
    public static class PaySlipConverter
    {
        public static PaySlipResponse ConvertToPaySlipResponse(PaySlipRecord record, IEnumerable<Link> links)
        {
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
                record.Requester,
                links);
        }
    }
}