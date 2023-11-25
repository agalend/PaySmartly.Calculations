using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public interface IPersistance
    {
        Task<PaySlipRecord> Create(PaySlip paySlip);
        Task<PaySlipRecord?> Get(string id);
        Task<PaySlipRecord?> Delete(string id);
    }

    public class Persistance : IPersistance
    {
        public Task<PaySlipRecord> Create(PaySlip paySlip)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecord?> Delete(string recordId)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecord?> Get(string recordId)
        {
            throw new NotImplementedException();
        }
    }
}