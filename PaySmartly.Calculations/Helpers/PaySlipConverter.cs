using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.HATEOAS;
using PaySmartly.Persistance;

namespace PaySmartly.Calculations.Helpers
{
    public static class PaySlipConverter
    {
        public static PaySlipResponse Convert(PaySlipRecord record, IEnumerable<Link> links)
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

        public static PaySlipRecord Convert(Record record)
        {
            PaySlipData data = record.Data;

            PaySlipRequest request = new(
                new EmployeeIdentity(data.EmployeeFirstName, data.EmployeeLastName),
                data.AnnualSalary,
                data.SuperRate,
                data.PayPeriod,
                data.RoundTo,
                data.Months,
                new RequesterIdentity(data.RequesterFirstName, data.RequesterLastName)
            );

            PaySlip paySlip = new(
                request,
                data.GrossIncome,
                data.IncomeTax,
                data.NetIncome,
                data.Super
            );

            PaySlipRecord paySlipRecord = new(record.Id, paySlip);
            return paySlipRecord;
        }

        public static CreateRequest Convert(PaySlip paySlip)
        {
            return new CreateRequest
            {
                Data = new PaySlipData
                {
                    EmployeeFirstName = paySlip.Employee.FirstName,
                    EmployeeLastName = paySlip.Employee.LastName,
                    AnnualSalary = paySlip.AnnualSalary,
                    SuperRate = paySlip.SuperRate,
                    PayPeriod = paySlip.PayPeriod,
                    RoundTo = paySlip.RoundTo,
                    Months = paySlip.Months,
                    GrossIncome = paySlip.GrossIncome,
                    IncomeTax = paySlip.IncomeTax,
                    NetIncome = paySlip.NetIncome,
                    Super = paySlip.Super,
                    RequesterFirstName = paySlip.Requester.FirstName,
                    RequesterLastName = paySlip.Requester.LastName
                }
            };
        }
    }
}