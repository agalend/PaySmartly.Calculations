using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public interface IPaySlipPersistance
    {
        Task<ServiceResult<PaySlipCreateRecordResponse>> CreatePaySlipRecord(PaySlipCreateRecordRequest createRecordRequest);
        Task<ServiceResult<PaySlipCreateRecordResponse>> GetPaySlipRecord(string id);
        Task<ServiceResult<PaySlipCreateRecordResponse>> DeletePaySlipRecord(string id);
    }

    public class PaySlipPersistance : IPaySlipPersistance
    {
        public Task<ServiceResult<PaySlipCreateRecordResponse>> CreatePaySlipRecord(PaySlipCreateRecordRequest createRecordRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<PaySlipCreateRecordResponse>> DeletePaySlipRecord(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<PaySlipCreateRecordResponse>> GetPaySlipRecord(string id)
        {
            throw new NotImplementedException();
        }
    }
}