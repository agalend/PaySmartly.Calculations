namespace PaySmartly.Calculations.Entities
{
    public record class TaxableIncomeTable(IReadOnlyCollection<TaxableRange> Ranges);
}