using Google.Protobuf.WellKnownTypes;
using PaySmartly.Calculations.Entities;
using PaySmartly.Persistance;

namespace PaySmartly.Calculations.Helpers
{
    public static class PaySlipConverter
    {
        public static PaySlipResponse Convert(PaySlipRecord record)
        {
            return new(
                record.Id,
                record.Employee,
                record.AnnualSalary,
                record.SuperRate,
                record.PayPeriodFrom,
                record.PayPeriodTo,
                record.GrossIncome,
                record.IncomeTax,
                record.NetIncome,
                record.Super,
                record.Requester,
                record.CreatedAt);
        }

        public static PaySlipRecord Convert(Record record)
        {
            PaySlipRequest request = new(
                new EmployeeIdentity(record.EmployeeFirstName, record.EmployeeLastName),
                record.AnnualSalary,
                record.SuperRate,
                record.PayPeriodFrom.ToDateTime(),
                record.PayPeriodTo.ToDateTime(),
                record.RoundTo,
                record.Months,
                new RequesterIdentity(record.RequesterFirstName, record.RequesterLastName)
            );

            PaySlip paySlip = new(
                request,
                record.GrossIncome,
                record.IncomeTax,
                record.NetIncome,
                record.Super,
                record.CreatedAt.ToDateTime()
            );

            PaySlipRecord paySlipRecord = new(record.Id, paySlip);
            return paySlipRecord;
        }

        public static CreateRequest Convert(PaySlip paySlip, DateTime createdAt)
        {
            return new CreateRequest
            {
                Record = new()
                {
                    EmployeeFirstName = paySlip.Employee.FirstName,
                    EmployeeLastName = paySlip.Employee.LastName,
                    AnnualSalary = paySlip.AnnualSalary,
                    SuperRate = paySlip.SuperRate,
                    PayPeriodFrom = paySlip.PayPeriodFrom.ToUniversalTime().ToTimestamp(),
                    PayPeriodTo = paySlip.PayPeriodTo.ToUniversalTime().ToTimestamp(),
                    RoundTo = paySlip.RoundTo,
                    Months = paySlip.Months,
                    GrossIncome = paySlip.GrossIncome,
                    IncomeTax = paySlip.IncomeTax,
                    NetIncome = paySlip.NetIncome,
                    Super = paySlip.Super,
                    RequesterFirstName = paySlip.Requester.FirstName,
                    RequesterLastName = paySlip.Requester.LastName,
                    CreatedAt = createdAt.ToUniversalTime().ToTimestamp()
                }
            };
        }

        public static TaxableIncomeTable Convert(PaySmartly.Legislation.TaxableIncomeTable table)
        {
            List<TaxableRange> ranges = [];
            foreach (var range in table.Ranges)
            {
                TaxableRange r = new(range.Start, range.End, range.Tax);
                ranges.Add(r);
            }

            TaxableIncomeTable taxableIncomeTable = new(ranges);
            return taxableIncomeTable;
        }
    }
}