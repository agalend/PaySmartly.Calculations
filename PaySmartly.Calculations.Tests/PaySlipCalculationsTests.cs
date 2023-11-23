using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations.Tests;

public class PaySlipCalculationsTests
{
    private readonly IPaySlipManager paySlipManager;

    public PaySlipCalculationsTests()
    {
        IPaySlipPersistance persistance = new InMemoryPaySlipPersistance(); // TODO: move InMemoryPaySlipPersistance to here
        ILegislationService legislation = new InMemoryLegislationService(); // TODO: move InMemoryLegislationService to here
        IPaySlipCalculator calculator = new PaySlipCalculator(new Formulas());
        paySlipManager = new PaySlipManager(persistance, legislation, calculator, new("0.1.0.0"));
    }

    // TODO: create more tests
    [Theory]
    [InlineData(60_050, 9, 500_4.17d, 919.58d, 4084.59d, 450.38d)]
    [InlineData(120_000, 10, 10_000d, 2543.33d, 7456.67d, 1000d)]
    [InlineData(120_000, 0, 10_000d, 2543.33d, 7456.67d, 0d)]
    [InlineData(0, 0, 0d, 0d, 0d, 0d)]
    public async Task TestPaySipCalculations(
        double annualSalary,
        double superRate,
        double expectedGrossIncome,
        double expectedIncomeTax,
        double expectedNetIncome,
        double expectedSuper)
    {
        PaySlipRequest paySlipRequest = CreatePaySlipRequest(annualSalary, superRate);
        PaySlipRecordDto? paySlipRecordDto = await paySlipManager.CreatePaySlip(paySlipRequest);

        Assert.Equal(paySlipRecordDto?.GrossIncome, expectedGrossIncome);
        Assert.Equal(paySlipRecordDto?.IncomeTax, expectedIncomeTax);
        Assert.Equal(paySlipRecordDto?.NetIncome, expectedNetIncome);
        Assert.Equal(paySlipRecordDto?.Super, expectedSuper);
    }

    // TODO: test incorrect input

    private PaySlipRequest CreatePaySlipRequest(double annualSalary, double superRate)
    {
        PaySlipRequest paySlipRequest = new(
            new("Stefan", "Bozov"),
            annualSalary,
             superRate,
            "March",
            2,
            12,
            new("Unknown", "Unknown"));

        return paySlipRequest;
    }
}