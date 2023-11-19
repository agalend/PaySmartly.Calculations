using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public interface IPaySlipPersistance
    {
        Task<PaySlipRecord> AddPaySlipRecord(PaySlipRecord paySlip);
        Task<PaySlipRecord?> GetPaySlipRecord(string id);
        Task<PaySlipRecord?> DeletePaySlipRecord(string id);
    }

    public class PaySlipPersistance : IPaySlipPersistance
    {
        public Task<PaySlipRecord> AddPaySlipRecord(PaySlipRecord paySlip)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecord?> DeletePaySlipRecord(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecord?> GetPaySlipRecord(string id)
        {
            throw new NotImplementedException();
        }
    }
}