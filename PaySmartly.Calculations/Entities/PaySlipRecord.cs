namespace PaySmartly.Calculations.Entities
{
    public record class PaySlipRecord : PaySlipCreateRecordRequest
    {
        public PaySlipRecord(
            string id,
            ServiceIdentity persistance,
            PaySlipCreateRecordRequest request)
                : base(request)
        {
            Id = id;
            Persistance = persistance;
        }

        public string Id { get; }
        public ServiceIdentity Persistance { get; }
    }
}