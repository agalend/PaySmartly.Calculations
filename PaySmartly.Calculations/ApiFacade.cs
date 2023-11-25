using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Filters;

namespace PaySmartly.Calculations
{
    // TODO: handle errors
    // TODO: HATEOAS 
    // TODO: add swagger 
    // TODO: add logging
    // TODO: add docker (publish the image somewhere)
    // TODO: write more unit tests
    // TODO: add integration tests
    // TODO: add github actions
    public class ApiFacade(WebApplication app)
    {
        private readonly WebApplication app = app;

        public void RegisterCreatePaySlipMethod()
        {
            app.MapPost("/payslips", async (UserRequest request, IManager manager) =>
            {
                RecordDto paySlip = await manager.CreatePaySlip(request);

                return paySlip;
            })
            .AddEndpointFilter<CreatePaySlipValidator>();
        }

        public void RegisterGetPaySlipMethod()
        {
            app.MapGet("/payslips/{id}", async (string id, IManager manager) =>
            {
                RecordDto? paySlip = await manager.GetPaySlip(id);

                return paySlip is null
                    ? Results.NotFound()
                    : Results.Ok(paySlip);

            })
            .AddEndpointFilter<GetPaySlipValidator>();
        }

        // There is no UpdatePaySlipMethod intentionally 

        public void RegisterDeletePaySlipMethod()
        {
            app.MapDelete("/payslips/{id}", async (string id, IManager manager) =>
            {
                RecordDto? paySlip = await manager.DeletePaySlip(id);

                return paySlip is null
                    ? Results.NotFound()
                    : Results.NoContent();

            })
            .AddEndpointFilter<DeletePaySlipValidator>();
        }

        public void Run()
        {
            app.Run();
        }
    }
}