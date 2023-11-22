using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations.Tests;

public class HelloWorldTests
{
    [Fact]
    public async Task TestRootEndpoint()
    {
        IPaySlipPersistance persistance = new InMemoryPaySlipPersistance();
        ILegislationService legislation = new InMemoryLegislationService();
        IPaySlipCalculator calculator = new PaySlipCalculator(new Formulas());

        IPaySlipManager manager = new PaySlipManager(persistance, legislation, calculator, new("0.1.0.0"));
        PaySlipRequest paySlipRequest = new(
            new("Stefan", "Bozov"),
            60_050,
             9,
            "March",
            2,
            12,
            new("Unknown", "Unknown"));

        PaySlipRecordDto? paySlipRecordDto = await manager.CreatePaySlip(paySlipRequest);
    }
}