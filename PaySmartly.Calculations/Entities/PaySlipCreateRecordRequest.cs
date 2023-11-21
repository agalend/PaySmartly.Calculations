namespace PaySmartly.Calculations.Entities
{
    public record class PaySlipCreateRecordRequest : CalculatedPaySlip
    {
        public PaySlipCreateRecordRequest(
            CalculatedPaySlip calculated,
            ServiceIdentity calculations,
            ServiceIdentity legislation)
                : base(calculated)
        {
            Calculations = calculations;
            Legislation = legislation;
        }

        public ServiceIdentity Calculations { get; }
        public ServiceIdentity Legislation { get; }
    }
}