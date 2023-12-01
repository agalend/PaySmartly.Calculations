using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Filters;

using static PaySmartly.Calculations.Helpers.PaySlipConverter;
using static PaySmartly.Calculations.Endpoints.PaySlipEndpoints;

namespace PaySmartly.Calculations
{
    // TODO: add proper configuration
    // TODO: add docker (publish the image to docker hub)
    // TODO: write more unit tests
    // TODO: add integration tests
    // TODO: add github actions
    // TODO: add distributed logging
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
            .WithName(HealthEndpoint.Name);
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
            .AddEndpointFilter<CreatePaySlipValidator>();
        }
    }
}