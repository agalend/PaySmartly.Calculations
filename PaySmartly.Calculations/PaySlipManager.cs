using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations
{
    public interface IPaySlipManager
    {
        Task<PaySlipRecordDto> CreatePaySlip(PaySlipRequest paySlip);
        Task<PaySlipRecordDto?> GetPaySlip(string id);
        Task<PaySlipRecordDto?> DeletePaySlip(string id);
    }

    public class PaySlipManager(
        IPaySlipPersistance persistance,
        ILegislationService legislationService,
        IPaySlipCalculator paySlipCalculator) : IPaySlipManager
    {
        private readonly ServiceIdentity IDENTITY = new("1.0.0.0");

        private readonly IPaySlipPersistance persistance = persistance;
        private readonly ILegislationService legislationService = legislationService;
        private readonly IPaySlipCalculator paySlipCalculator = paySlipCalculator;

        public async Task<PaySlipRecordDto> CreatePaySlip(PaySlipRequest paySlipRequest)
        {
            //TODO: do not use table.Result here, do it clearer
            ServiceResult<TaxableIncomeTable> table = await legislationService.GetTaxableIncomeTable();

            PaySlip calculatedPaySlip = paySlipCalculator.Calculate(paySlipRequest, table.Result);

            PaySlipRecord paySlipRecord = ConvertToPlaySlipRecord(calculatedPaySlip);

            PaySlipRecord addedPaySlipRecord = await persistance.AddPaySlipRecord(paySlipRecord);

            PaySlipRecordDto? paySlipDto = ConvertToPlaySlipRecordDto(addedPaySlipRecord);

            return paySlipDto;
        }

        public async Task<PaySlipRecordDto?> GetPaySlip(string id)
        {
            PaySlipRecord? addedRecord = await persistance.GetPaySlipRecord(id);

            PaySlipRecordDto? paySlipDto = addedRecord == null
                ? default
                : ConvertToPlaySlipRecordDto(addedRecord);

            return paySlipDto;
        }

        public async Task<PaySlipRecordDto?> DeletePaySlip(string id)
        {
            PaySlipRecord? deletedPaySlipRecord = await persistance.DeletePaySlipRecord(id);

            PaySlipRecordDto? paySlipDto = deletedPaySlipRecord == null
                ? default
                : ConvertToPlaySlipRecordDto(deletedPaySlipRecord);

            return paySlipDto;
        }

        // TODO: create PaySlipConverter and remove below methods from this class

        private PaySlipRecord ConvertToPlaySlipRecord(PaySlip record)
        {
            throw new NotImplementedException();
        }

        private PaySlipRecordDto ConvertToPlaySlipRecordDto(PaySlipRecord record)
        {
            throw new NotImplementedException();
        }
    }
}