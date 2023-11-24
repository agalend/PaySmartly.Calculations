using System.Collections.Concurrent;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public class InMemoryPersistance : IPersistance
    {
        private int currentId = -1;
        private readonly ConcurrentDictionary<string, Record> records = new();

        public Task<Record> Create(PaySlip paySlip)
        {
            string id = GenerateNextId(ref currentId);

            Record record = new(id, paySlip);
            Record added = records.AddOrUpdate(id, record, (key, old) => record);

            return Task.FromResult(added);
        }

        public Task<Record?> Get(string recordId)
        {
            records.TryGetValue(recordId, out Record? record);

            return Task.FromResult(record);
        }

        public Task<Record?> Delete(string recordId)
        {
            records.Remove(recordId, out Record? record);

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