
using System.Globalization;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Filters
{
    public class CreatePaySlipValidator : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var userRequest = context.GetArgument<PaySlipRequest>(0);

            EmployeeIdentity? employee = userRequest?.Employee;
            if (string.IsNullOrEmpty(employee?.FirstName) || string.IsNullOrEmpty(employee?.LastName))
            {
                return Results.BadRequest($"Invalid {nameof(employee)} value, you should provide non empty first and last names");
            }

            double? annualSalary = userRequest?.AnnualSalary;
            if (annualSalary is null || annualSalary <= 0d)
            {
                return Results.BadRequest($"Invalid {nameof(annualSalary)} value, you should provide a positive, bigger than 0 annual salary");
            }

            double? superRate = userRequest?.SuperRate;
            if (superRate is null || superRate <= 0d)
            {
                return Results.BadRequest($"Invalid {nameof(superRate)} value, you should provide a positive, bigger than 0 super rate");
            }

            string? payPeriod = userRequest?.PayPeriod;
            if (
                string.IsNullOrEmpty(payPeriod) ||
                !DateTimeFormatInfo.CurrentInfo.MonthNames.Any(month => month.Equals(payPeriod, StringComparison.CurrentCultureIgnoreCase)))
            {
                return Results.BadRequest($"Invalid {nameof(payPeriod)} value, you should provide a valid month's name");
            }

            int? roundTo = userRequest?.RoundTo;
            if (roundTo is null || roundTo < 0)
            {
                return Results.BadRequest($"Invalid {nameof(roundTo)} value, you should provide a positive number");
            }

            int? months = userRequest?.Months;
            if (roundTo is null || (months < 1 || months > 12))
            {
                return Results.BadRequest($"Invalid {nameof(months)} value, you should provide a positive number between 1 and 12");
            }

            RequesterIdentity? requester = userRequest?.Requester;
            if (string.IsNullOrEmpty(requester?.FirstName) || string.IsNullOrEmpty(requester?.LastName))
            {
                return Results.BadRequest($"Invalid {nameof(requester)} value, you should provide non empty first and last names");
            }

            return await next(context);
        }
    }
}