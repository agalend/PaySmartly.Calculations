using static PaySmartly.Calculations.WebApplicationFactory;

namespace PaySmartly.Calculations
{
    public class App
    {
        public void Run(string[] args)
        {
            WebApplication app = CreateWebApplication(args);
            ApiFacade facade = new(app);

            facade.RegisterHealthMethod();
            facade.RegisterCreatePaySlipMethod();

            facade.Run();
        }
    }
}