using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations.Tests;

public class CalculationsTests
{
    private readonly IManager paySlipManager;

    public CalculationsTests()
    {
        IPersistance persistance = new InMemoryPersistance(); // TODO: move InMemoryPaySlipPersistance to here
        ILegislation legislation = new InMemoryLegislationService(); // TODO: move InMemoryLegislationService to here
        ICalculator calculator = new Calculator(new Formulas());

        paySlipManager = new Manager(persistance, legislation, calculator);
    }

    // normal tests
    [Theory]
    [InlineData(60_050, 9, 5_004.17d, 919.58d, 4_084.59d, 450.38d)]
    [InlineData(120_000, 10, 10_000d, 2_543.33d, 7_456.67d, 1_000d)]
    [InlineData(50_000, 4, 4_166.67d, 668.33d, 3_498.34d, 166.67d)]
    [InlineData(251_005, 3, 20_917.08, 6501d, 14_416.08d, 627.51d)]
    [InlineData(1_000_000, 3, 83_333.33d, 30_843.33d, 52_490d, 2500d)]
    // TODO: create more tests

    // test edge cases
    [InlineData(0, 0, 0d, 0d, 0d, 0d)]
    [InlineData(120_000, 0, 10_000d, 2_543.33d, 7_456.67d, 0d)]
    [InlineData(1, 0, 0.08d, 0d, 0.08d, 0d)]
    // TODO: create more tests
    public async Task TestRegularPaySipCalculations(
        double annualSalary,
        double superRate,
        double expectedGrossIncome,
        double expectedIncomeTax,
        double expectedNetIncome,
        double expectedSuper)
    {
        PaySlipRequest paySlipRequest = CreatePaySlipRequest(annualSalary, superRate);
        PaySlipRecord? paySlipRecord = await paySlipManager.CreatePaySlip(paySlipRequest);

        Assert.Equal(paySlipRecord?.GrossIncome, expectedGrossIncome);
        Assert.Equal(paySlipRecord?.IncomeTax, expectedIncomeTax);
        Assert.Equal(paySlipRecord?.NetIncome, expectedNetIncome);
        Assert.Equal(paySlipRecord?.Super, expectedSuper);
    }

    private PaySlipRequest CreatePaySlipRequest(double annualSalary, double superRate)
    {
        PaySlipRequest paySlipRequest = new(
            new("Stefan", "Bozov"),
            annualSalary,
             superRate,
            DateTime.Now,
            DateTime.Now,
            2,
            12,
            new("Stefan", "Bozov"));

        return paySlipRequest;
    }
}