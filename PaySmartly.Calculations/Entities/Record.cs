namespace PaySmartly.Calculations.Entities
{
    public record class Record : PaySlip
    {
        public Record(
            string id,
            PaySlip request)
                : base(request)
        {
            Id = id;
        }

        public string Id { get; }
    }
}