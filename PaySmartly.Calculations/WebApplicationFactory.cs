using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Exceptions;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations
{
    public static class WebApplicationFactory
    {
        // TODO: set service name somewhere!!!
        private static readonly string ServiceName = "Calculations Service";

        public static WebApplication CreateWebApplication(string[] args)
        {
            // will use CreateSlimBuilder in order to be prepared for an AOT compilation
            WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
            AddOpenTelemetryLogging(builder);
            AddServices(builder);

            WebApplication app = builder.Build();
            AddExceptionHandling(app);
            AddSwagger(app);
            return app;
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            AddOpenTelemetryService(builder);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IPersistance, InMemoryPersistance>(); // Singleton or Scoped ??? Will decide after implementing the grpc client
            builder.Services.AddSingleton<ILegislation, InMemoryLegislationService>(); // Singleton or Scoped ??? Will decide after implementing the grpc client
            builder.Services.AddScoped<IFormulas, Formulas>();
            builder.Services.AddScoped<ICalculator, Calculator>();
            builder.Services.AddScoped<IManager, Manager>();
        }

        private static void AddOpenTelemetryLogging(WebApplicationBuilder builder)
        {
            builder.Logging.AddOpenTelemetry(options =>
            {
                ResourceBuilder resourceBuilder = ResourceBuilder.CreateDefault().AddService(ServiceName);

                options.SetResourceBuilder(resourceBuilder).AddConsoleExporter();
            });
        }

        private static void AddOpenTelemetryService(WebApplicationBuilder builder)
        {
            OpenTelemetryBuilder openTelemetryBuilder = builder.Services.AddOpenTelemetry();

            openTelemetryBuilder = openTelemetryBuilder.ConfigureResource(resource => resource.AddService(ServiceName));

            openTelemetryBuilder = openTelemetryBuilder.WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation().AddConsoleExporter();
            });
            openTelemetryBuilder = openTelemetryBuilder.WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation().AddConsoleExporter();
            });
        }

        private static void AddExceptionHandling(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                ExceptionHandler handler = new();
                app.UseExceptionHandler(exceptionHandlerApp => handler.Build(exceptionHandlerApp));
            }
        }

        private static void AddSwagger(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}