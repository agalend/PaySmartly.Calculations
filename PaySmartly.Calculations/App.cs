namespace PaySmartly.Calculations
{
    public class App
    {
        public void Run(string[] args)
        {
            // will use CreateSlimBuilder in order to be prepared for an AOT compilation
            var builder = WebApplication.CreateSlimBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}