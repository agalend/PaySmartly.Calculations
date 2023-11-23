using System.Collections.Concurrent;
using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public class InMemoryPaySlipPersistance : IPaySlipPersistance
    {
        private int currentId = -1;
        private readonly ConcurrentDictionary<string, PaySlipRecord> paySlipRecords = new();

        public Task<ServiceResult<PaySlipCreateRecordResponse>> CreatePaySlipRecord(PaySlipCreateRecordRequest request)
        {
            string id = GenerateNextId(ref currentId);
            PaySlipRecord record = new(id, Identity, request);

            PaySlipRecord addedRecord = paySlipRecords.AddOrUpdate(id, record, (key, old) => record);

            PaySlipCreateRecordResponse response = new(addedRecord);
            ServiceResult<PaySlipCreateRecordResponse> result = new(response, Identity);

            return Task.FromResult(result);
        }

        public ServiceIdentity Identity { get; } = new("0.1.0.0");

        public Task<ServiceResult<PaySlipCreateRecordResponse>> GetPaySlipRecord(string id)
        {
            paySlipRecords.TryGetValue(id, out PaySlipRecord? record);

            PaySlipCreateRecordResponse response = record is null ? new(default) : new(record);


            ServiceResult<PaySlipCreateRecordResponse> result = new(response, Identity);
            return Task.FromResult(result);
        }

        public Task<ServiceResult<PaySlipCreateRecordResponse>> DeletePaySlipRecord(string id)
        {
            paySlipRecords.Remove(id, out PaySlipRecord? record);

            PaySlipCreateRecordResponse response = record is null ? new(default) : new(record);

            ServiceResult<PaySlipCreateRecordResponse> result = new(response, Identity);

            return Task.FromResult(result);
        }

        private static string GenerateNextId(ref int previousId)
        {
            int id = Interlocked.Increment(ref previousId);
            string strId = id.ToString();
            return strId;
        }
    }
}