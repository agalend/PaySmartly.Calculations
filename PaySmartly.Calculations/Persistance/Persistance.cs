using PaySmartly.Calculations.Entities;
using PaySmartly.Persistance;
using static PaySmartly.Persistance.Persistance;
using static PaySmartly.Calculations.Helpers.PaySlipConverter;

namespace PaySmartly.Calculations.Persistance
{
    public interface IPersistance
    {
        Task<PaySlipRecord?> Create(PaySlip paySlip);
        Task<PaySlipRecord?> Get(string id);
        Task<PaySlipRecord?> Delete(string id);
    }

    public class Persistance(PersistanceClient client) : IPersistance
    {
        private readonly PersistanceClient persistanceClient = client;

        public async Task<PaySlipRecord?> Create(PaySlip paySlip)
        {
            DateTime createdAt = DateTime.UtcNow;
            CreateRequest request = Convert(paySlip, createdAt);
            Response response = await persistanceClient.CreateAsync(request);

            return !response.Exists ? default : Convert(response.Record);
        }

        public async Task<PaySlipRecord?> Get(string recordId)
        {
            GetRequest request = new() { Id = recordId };
            Response response = await persistanceClient.GetAsync(request);

            return !response.Exists ? default : Convert(response.Record);
        }

        public async Task<PaySlipRecord?> Delete(string recordId)
        {
            DeleteRequest request = new() { Id = recordId };
            Response response = await persistanceClient.DeleteAsync(request);

            return !response.Exists ? default : Convert(response.Record);
        }
    }
}