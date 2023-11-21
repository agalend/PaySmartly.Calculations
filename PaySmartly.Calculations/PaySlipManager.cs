using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

using static PaySmartly.Calculations.Helpers.PaySlipConverter;

namespace PaySmartly.Calculations
{
    public interface IPaySlipManager
    {
        Task<PaySlipRecordDto?> CreatePaySlip(PaySlipRequest paySlipRequest);
        Task<PaySlipRecordDto?> GetPaySlip(string id);
        Task<PaySlipRecordDto?> DeletePaySlip(string id);
    }

    public class PaySlipManager(
        IPaySlipPersistance persistance,
        ILegislationService legislation,
        IPaySlipCalculator calculator,
        ServiceIdentity myIdentity) : IPaySlipManager
    {
        private readonly IPaySlipPersistance persistance = persistance;
        private readonly ILegislationService legislation = legislation;
        private readonly IPaySlipCalculator calculator = calculator;
        private readonly ServiceIdentity myIdentity = myIdentity;

        public async Task<PaySlipRecordDto?> CreatePaySlip(PaySlipRequest paySlipRequest)
        {
            PaySlipCreateRecordRequest createRecordRequest = await CalculatePaySlip(paySlipRequest);

            ServiceResult<PaySlipCreateRecordResponse> persistanceServiceResult = await persistance.CreatePaySlipRecord(createRecordRequest);
            PaySlipRecord? paySlipRecord = persistanceServiceResult.Value.PaySlipRecord;

            PaySlipRecordDto? paySlipDto = paySlipRecord == null
                ? default
                : ConvertToPlaySlipRecordDto(paySlipRecord);

            return paySlipDto;
        }

        public async Task<PaySlipRecordDto?> GetPaySlip(string id)
        {
            ServiceResult<PaySlipCreateRecordResponse> result = await persistance.GetPaySlipRecord(id);
            PaySlipRecord? record = result.Value.PaySlipRecord;

            PaySlipRecordDto? paySlipDto = record == null
                ? default
                : ConvertToPlaySlipRecordDto(record);

            return paySlipDto;
        }

        public async Task<PaySlipRecordDto?> DeletePaySlip(string id)
        {
            ServiceResult<PaySlipCreateRecordResponse> result = await persistance.DeletePaySlipRecord(id);
            PaySlipRecord? record = result.Value.PaySlipRecord;

            PaySlipRecordDto? paySlipDto = record == null
                ? default
                : ConvertToPlaySlipRecordDto(record);

            return paySlipDto;
        }

        private async Task<PaySlipCreateRecordRequest> CalculatePaySlip(PaySlipRequest paySlipRequest)
        {
            ServiceResult<TaxableIncomeTable> legislationResult = await legislation.GetTaxableIncomeTable(paySlipRequest.PayPeriod);
            ServiceIdentity legislationIdentity = legislationResult.ServiceIdentity;
            TaxableIncomeTable taxableIncomeTable = legislationResult.Value;

            CalculatedPaySlip calculated = calculator.Calculate(paySlipRequest, taxableIncomeTable);
            PaySlipCreateRecordRequest request = ConvertToPlaySlipCreateRecordRequest(calculated, legislationIdentity, myIdentity);
            return request;
        }
    }
}