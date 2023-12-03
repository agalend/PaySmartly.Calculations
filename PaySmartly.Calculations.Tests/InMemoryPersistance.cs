using System.Collections.Concurrent;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations.Tests
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

        private static string GenerateNextId(ref int previousId)
        {
            int id = Interlocked.Increment(ref previousId);
            string strId = id.ToString();
            return strId;
        }
    }
}