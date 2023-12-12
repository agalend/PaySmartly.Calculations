using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Filters;

using static PaySmartly.Calculations.Helpers.PaySlipConverter;
using static PaySmartly.Calculations.Endpoints.PaySlipEndpoints;
using System.Net;

namespace PaySmartly.Calculations
{
    public class ApiFacade(WebApplication app)
    {
        private readonly WebApplication app = app;

        public void Run()
        {
            app.Run();
        }

        public void RegisterHealthMethod()
        {
            app.MapGet(HealthEndpoint.Pattern, () =>
            {
                return Results.Ok();
            })
            .WithName(HealthEndpoint.Name)
            .WithOpenApi();
        }

        public void RegisterCreatePaySlipMethod()
        {
            app.MapPost(CreateEndpoint.Pattern, async (PaySlipRequest request, IManager manager) =>
            {
                PaySlipRecord? paySlip = await manager.CreatePaySlip(request);

                if (paySlip is null)
                {
                    return Results.Conflict();
                }
                else
                {
                    PaySlipResponse response = Convert(paySlip);
                    return Results.Ok(response);
                }
            })
            .WithName(CreateEndpoint.Name)
            .WithOpenApi()
            .Produces<PaySlipResponse>((int)HttpStatusCode.OK)
            .AddEndpointFilter<CreatePaySlipValidator>();
        }
    }
}