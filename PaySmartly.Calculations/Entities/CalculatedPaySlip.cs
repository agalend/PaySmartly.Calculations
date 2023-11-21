namespace PaySmartly.Calculations.Entities
{
    public record class CalculatedPaySlip : PaySlipRequest
    {
        public CalculatedPaySlip(
            PaySlipRequest request,
            ResultWithFormula<double> grossIncome,
            ResultWithFormula<double> incomeTax,
            ResultWithFormula<double> netIncome,
            ResultWithFormula<double> super)
                : base(request)
        {
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }

        public ResultWithFormula<double> GrossIncome { get; }
        public ResultWithFormula<double> IncomeTax { get; }
        public ResultWithFormula<double> NetIncome { get; }
        public ResultWithFormula<double> Super { get; }
    }
}