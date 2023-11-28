using System.Collections.Concurrent;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public class InMemoryPersistance : IPersistance
    {
        private int currentId = -1;
        private readonly ConcurrentDictionary<string, PaySlipRecord> records = new();

        public Task<PaySlipRecord?> Create(PaySlip paySlip)
        {
            string id = GenerateNextId(ref currentId);

            PaySlipRecord record = new(id, paySlip);
            PaySlipRecord added = records.AddOrUpdate(id, record, (key, old) => record);

            return Task.FromResult<PaySlipRecord?>(added);
        }

        public Task<PaySlipRecord?> Get(string recordId)
        {
            records.TryGetValue(recordId, out PaySlipRecord? record);

            return Task.FromResult(record);
        }

        public Task<PaySlipRecord?> Delete(string recordId)
        {
            records.Remove(recordId, out PaySlipRecord? record);

            return Task.FromResult(record);
        }

        private static string GenerateNextId(ref int previousId)
        {
            int id = Interlocked.Increment(ref previousId);
            string strId = id.ToString();
            return strId;
        }
    }
}