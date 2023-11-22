using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations
{
    public class App
    {
        public void Run(string[] args)
        {
            WebApplication app = CreateWebApplication(args);


            app.MapPost("/payslips", async (PaySlipRequest request, IPaySlipManager paySlipManager) =>
            {
                PaySlipRecordDto? paySlipRecordDto = await paySlipManager.CreatePaySlip(request);
                if (paySlipRecordDto == null)
                {
                    return Results.Problem();
                }
                else
                {
                    return Results.Created($"/payslips/{paySlipRecordDto.Id}", paySlipRecordDto);
                }
            });

            app.Run();
        }

        private WebApplication CreateWebApplication(string[] args)
        {
            // will use CreateSlimBuilder in order to be prepared for an AOT compilation
            WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.AddSingleton<IPaySlipPersistance, InMemoryPaySlipPersistance>(); // Singleton or Scoped ??? Will decide after implementing the grpc client
            builder.Services.AddSingleton<ILegislationService, InMemoryLegislationService>(); // Singleton or Scoped ??? Will decide after implementing the grpc client
            builder.Services.AddScoped<IFormulas, Formulas>();
            builder.Services.AddScoped<IPaySlipCalculator, PaySlipCalculator>();
            builder.Services.AddScoped<IPaySlipManager, PaySlipManager>();

            WebApplication app = builder.Build();
            return app;
        }
    }
}