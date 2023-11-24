using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

using static PaySmartly.Calculations.Helpers.RecordConverter;

namespace PaySmartly.Calculations
{
    public interface IManager
    {
        Task<RecordDto> CreatePaySlip(UserRequest request);
        Task<RecordDto?> GetPaySlip(string recordId);
        Task<RecordDto?> DeletePaySlip(string recordId);
    }

    public class Manager(
        IPersistance persistance,
        ILegislation legislation,
        ICalculator calculator) : IManager
    {
        private readonly IPersistance persistance = persistance;
        private readonly ILegislation legislation = legislation;
        private readonly ICalculator calculator = calculator;

        public async Task<RecordDto> CreatePaySlip(UserRequest request)
        {
            TaxableIncomeTable table = await legislation.GetTaxableIncomeTable(request.PayPeriod);

            PaySlip paySlip = calculator.Calculate(request, table);

            Record record = await persistance.Create(paySlip);

            RecordDto recordDto = ConvertToRecordDto(record);

            return recordDto;
        }

        public async Task<RecordDto?> GetPaySlip(string recordId)
        {
            Record? record = await persistance.Get(recordId);

            RecordDto? recordDto = record is null
                ? default
                : ConvertToRecordDto(record);

            return recordDto;
        }

        public async Task<RecordDto?> DeletePaySlip(string recordId)
        {
            Record? record = await persistance.Delete(recordId);

            RecordDto? recordDto = record is null
                ? default
                : ConvertToRecordDto(record);

            return recordDto;
        }
    }
}