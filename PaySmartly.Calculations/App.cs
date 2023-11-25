using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.HATEOAS;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations
{
    public class App
    {
        public void Run(string[] args)
        {
            WebApplication app = CreateWebApplication(args);

            ApiFacade facade = new(app);

            facade.RegisterCreatePaySlipMethod();
            facade.RegisterGetPaySlipMethod();
            facade.RegisterDeletePaySlipMethod();

            facade.Run();
        }

        private WebApplication CreateWebApplication(string[] args)
        {
            // will use CreateSlimBuilder in order to be prepared for an AOT compilation
            WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
            builder = AddServices(builder);

            WebApplication app = builder.Build();
            app = AddExceptionHandling(app);
            return app;
        }

        private WebApplicationBuilder AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IPersistance, InMemoryPersistance>(); // Singleton or Scoped ??? Will decide after implementing the grpc client
            builder.Services.AddSingleton<ILegislation, InMemoryLegislationService>(); // Singleton or Scoped ??? Will decide after implementing the grpc client
            builder.Services.AddScoped<IFormulas, Formulas>();
            builder.Services.AddScoped<ICalculator, Calculator>();
            builder.Services.AddScoped<IManager, Manager>();
            return builder;
        }

        private WebApplication AddExceptionHandling(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(exceptionHandlerApp =>
                {
                    exceptionHandlerApp.Run(async context =>
                    {
                        await Results.Problem().ExecuteAsync(context);
                    });
                });
            }

            return app;
        }
    }
}