using PaySmartly.Calculations.Entities;
using PaySmartly.Persistance;
using static PaySmartly.Persistance.Persistance;
using static PaySmartly.Calculations.Helpers.PaySlipConverter;

namespace PaySmartly.Calculations.Persistance
{
    public interface IPersistance
    {
        Task<PaySlipRecord> Create(PaySlip paySlip);
        Task<PaySlipRecord?> Get(string id);
        Task<PaySlipRecord?> Delete(string id);
    }

    public class Persistance(PersistanceClient client) : IPersistance
    {
        private readonly PersistanceClient client = client;

        public async Task<PaySlipRecord> Create(PaySlip paySlip)
        {
            CreateRequest request = Convert(paySlip);
            Record record = await client.CreateAsync(request);

            PaySlipRecord paySlipRecord = Convert(record);
            return paySlipRecord;
        }

        public async Task<PaySlipRecord?> Get(string recordId)
        {
            GetRequest request = new() { Id = recordId };
            Record record = await client.GetAsync(request);

            return record.Data is null
            ? default
            : Convert(record);
        }

        public async Task<PaySlipRecord?> Delete(string recordId)
        {
            DeleteRequest request = new() { Id = recordId };
            Record record = await client.DeleteAsync(request);

            return record.Data is null
            ? default
            : Convert(record);
        }
    }
}