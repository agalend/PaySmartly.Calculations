using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Filters;
using PaySmartly.Calculations.HATEOAS;
using static PaySmartly.Calculations.Helpers.PaySlipConverter;

namespace PaySmartly.Calculations
{
    // TODO: add logging
    // TODO: add docker (publish the image somewhere)
    // TODO: write more unit tests
    // TODO: add integration tests
    // TODO: add github actions
    public class ApiFacade(WebApplication app)
    {
        private readonly string createEndpointName = "createpayslip";
        private readonly string getEndpointName = "getpayslipbyid";
        private readonly string deleteEndpointName = "deletepayslipbyid";

        private readonly WebApplication app = app;

        public void RegisterCreatePaySlipMethod()
        {
            app.MapPost("/payslips", async (PaySlipRequest request, IManager manager, HttpContext context, LinkGenerator linkGenerator) =>
            {
                PaySlipRecord paySlip = await manager.CreatePaySlip(request);

                IEnumerable<Link> links =
                [
                    new (linkGenerator.GetUriByName(context, getEndpointName, values: new{paySlip.Id}), "get_payslip", "GET"),
                    new (linkGenerator.GetUriByName(context, deleteEndpointName, values: new{paySlip.Id}), "delete_payslip", "DELETE")
                ];

                PaySlipResponse response = ConvertToPaySlipResponse(paySlip, links);

                return Results.Ok(response);
            })
            .WithName(createEndpointName)
            .WithOpenApi()
            .AddEndpointFilter<CreatePaySlipValidator>();
        }

        public void RegisterGetPaySlipMethod()
        {
            app.MapGet("/payslips/{id}", async (string id, IManager manager, HttpContext context, LinkGenerator linkGenerator) =>
            {
                PaySlipRecord? paySlip = await manager.GetPaySlip(id);

                if (paySlip is null)
                {
                    return Results.NotFound();
                }
                else
                {
                    IEnumerable<Link> links =
                    [
                        new (linkGenerator.GetUriByName(context, getEndpointName, values: new{paySlip.Id}), "self", "GET"),
                        new (linkGenerator.GetUriByName(context, deleteEndpointName, values: new{paySlip.Id}), "delete_payslip", "DELETE")
                    ];

                    PaySlipResponse response = ConvertToPaySlipResponse(paySlip, links);

                    return Results.Ok(response); ;
                }
            })
            .WithName(getEndpointName)
            .WithOpenApi()
            .AddEndpointFilter<GetPaySlipValidator>();
        }

        // There is no UpdatePaySlipMethod intentionally 

        public void RegisterDeletePaySlipMethod()
        {
            app.MapDelete("/payslips/{id}", async (string id, IManager manager) =>
            {
                PaySlipRecord? paySlip = await manager.DeletePaySlip(id);

                if (paySlip is null)
                {
                    return Results.NotFound();
                }
                else
                {
                    PaySlipResponse response = ConvertToPaySlipResponse(paySlip, new List<Link>());
                    return Results.Ok(response);
                }

            })
            .WithName(deleteEndpointName)
            .WithOpenApi()
            .AddEndpointFilter<DeletePaySlipValidator>();
        }

        public void Run()
        {
            app.Run();
        }
    }
}