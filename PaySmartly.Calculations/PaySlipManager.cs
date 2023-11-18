using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations
{
    // TODO: add limit and pagination !!!
    public interface IPaySlipManager
    {
        Task<PaySlipRecordDto> CreatePaySlip(PaySlip paySlip);
        Task<PaySlipRecordDto> GetPaySlip(string id);
        Task<PaySlipRecordDto> UpdatePaySlip(string id, PaySlip paySlip);
        Task<PaySlipRecordDto> DeletePaySlip(string id);
        Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByDate(DateTime from, DateTime To);
        Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByName(string name);
        Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByIRD(string ird);
    }

    public class PaySlipManager : IPaySlipManager
    {
        public Task<PaySlipRecordDto> CreatePaySlip(PaySlip paySlip)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecordDto> DeletePaySlip(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByDate(DateTime from, DateTime To)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByIRD(string ird)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecordDto> GetPaySlip(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PaySlipRecordDto> UpdatePaySlip(string id, PaySlip paySlip)
        {
            throw new NotImplementedException();
        }
    }
}