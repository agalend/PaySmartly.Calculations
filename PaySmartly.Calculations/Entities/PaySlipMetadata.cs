namespace PaySmartly.Calculations.Entities
{
    public record class PaySlipMetadata(
        string CalculationsService,
        string LegislationService,
        string Requester
    );
}