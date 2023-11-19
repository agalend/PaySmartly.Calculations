using System.Collections.Concurrent;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public class InMemoryPaySlipPersistance : IPaySlipPersistance
    {
        private int currentId = -1;
        private readonly ConcurrentDictionary<string, PaySlipRecord> paySlipRecords = new();

        public Task<PaySlipRecord> AddPaySlipRecord(PaySlipRecord paySlip)
        {
            string id = GenerateNextId(ref currentId);

            // we are not going to update any dictionary record, and therefore, below line should be reliable enough 
            PaySlipRecord record = paySlipRecords.AddOrUpdate(id, paySlip, (key, old) => paySlip);

            return Task.FromResult(record);
        }

        public Task<PaySlipRecord?> GetPaySlipRecord(string id)
        {
            paySlipRecords.TryGetValue(id, out PaySlipRecord? paySlipRecord);

            return Task.FromResult(paySlipRecord);
        }

        public Task<PaySlipRecord?> DeletePaySlipRecord(string id)
        {
            paySlipRecords.Remove(id, out PaySlipRecord? paySlipRecord);

            return Task.FromResult(paySlipRecord);
        }

        private static string GenerateNextId(ref int previousId)
        {
            int id = Interlocked.Increment(ref previousId);
            string strId = id.ToString();
            return strId;
        }
    }
}