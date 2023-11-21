namespace PaySmartly.Calculations.Entities
{
    public record class CalculatedPaySlip : PaySlipRequest
    {
        public CalculatedPaySlip(
            PaySlipRequest request,
            double grossIncome,
            double incomeTax,
            double netIncome,
            double super)
                : base(request)
        {
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }

        public double GrossIncome { get; }
        public double IncomeTax { get; }
        public double NetIncome { get; }
        public double Super { get; }
    }
}