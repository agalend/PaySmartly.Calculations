using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public interface IPaySlipPersistance
    {
        Task<PaySlipRecord> AddPaySlip(PaySlipRecord paySlip);
        Task<PaySlipRecord> GetPaySlip(string id);
        Task<PaySlipRecord> DeletePaySlip(string id);
    }

    public class PaySlipPersistance : IPaySlipPersistance
    {
        public Task<PaySlipRecord> AddPaySlip(PaySlipRecord paySlip)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecord> DeletePaySlip(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecord> GetPaySlip(string id)
        {
            throw new NotImplementedException();
        }
    }
}