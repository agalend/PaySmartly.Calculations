using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Filters;
using PaySmartly.Calculations.HATEOAS;

using static PaySmartly.Calculations.Helpers.PaySlipConverter;
using static PaySmartly.Calculations.Endpoints.PaySlipEndpoints;

namespace PaySmartly.Calculations
{
    // TODO: add grpc client to the persistance
    // TODO: add grpc client to the legislation
    // TODO: add proper configuration
    // TODO: add docker (publish the image to docker hub)
    // TODO: write more unit tests
    // TODO: add integration tests
    // TODO: add github actions
    // TODO: add distributed logging
    public class ApiFacade(WebApplication app)
    {
        private readonly WebApplication app = app;

        public void RegisterCreatePaySlipMethod()
        {
            app.MapPost(CreateEndpoint.Pattern, async (PaySlipRequest request, IManager manager, HttpContext context, LinkGenerator linkGenerator) =>
            {
                PaySlipRecord paySlip = await manager.CreatePaySlip(request);

                IEnumerable<Link> links =
                [
                    new (linkGenerator.GetUriByName(context, GetEndpoint.Name, values: new{paySlip.Id}), GetEndpoint.Name, GetEndpoint.Method),
                    new (linkGenerator.GetUriByName(context, DeleteEndpoint.Name, values: new{paySlip.Id}), DeleteEndpoint.Name, DeleteEndpoint.Method)
                ];

                PaySlipResponse response = ConvertToResponse(paySlip, links);

                return Results.Ok(response);
            })
            .WithName(CreateEndpoint.Name)
            .WithOpenApi()
            .AddEndpointFilter<CreatePaySlipValidator>();
        }

        public void RegisterGetPaySlipMethod()
        {
            app.MapGet(GetEndpoint.Pattern, async (string id, IManager manager, HttpContext context, LinkGenerator linkGenerator) =>
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
                        new (linkGenerator.GetUriByName(context, GetEndpoint.Name, values: new{paySlip.Id}),"self", GetEndpoint.Method),
                        new (linkGenerator.GetUriByName(context, DeleteEndpoint.Name, values: new{paySlip.Id}), DeleteEndpoint.Name, DeleteEndpoint.Method)
                    ];

                    PaySlipResponse response = ConvertToResponse(paySlip, links);

                    return Results.Ok(response); ;
                }
            })
            .WithName(GetEndpoint.Name)
            .WithOpenApi()
            .AddEndpointFilter<GetPaySlipValidator>();
        }

        // There is no UpdatePaySlipMethod intentionally 

        public void RegisterDeletePaySlipMethod()
        {
            app.MapDelete(DeleteEndpoint.Pattern, async (string id, IManager manager) =>
            {
                PaySlipRecord? paySlip = await manager.DeletePaySlip(id);

                if (paySlip is null)
                {
                    return Results.NotFound();
                }
                else
                {
                    PaySlipResponse response = ConvertToResponse(paySlip, new List<Link>());
                    return Results.Ok(response);
                }

            })
            .WithName(DeleteEndpoint.Name)
            .WithOpenApi()
            .AddEndpointFilter<DeletePaySlipValidator>();
        }

        public void Run()
        {
            app.Run();
        }
    }
}