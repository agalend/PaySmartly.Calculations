using PaySmartly.Calculations.Calculations;
using PaySmartly.Calculations.Entities;
using PaySmartly.Calculations.Legislation;
using PaySmartly.Calculations.Persistance;

namespace PaySmartly.Calculations
{
    // TODO: add limit and pagination !!!
    public interface IPaySlipManager
    {
        Task<PaySlipRecordDto> CreatePaySlip(PaySlip paySlip);
        Task<PaySlipRecordDto> GetPaySlip(string id);
        Task<PaySlipRecordDto> DeletePaySlip(string id);
        Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByDate(DateTime from, DateTime To);
        Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByName(string name);
        Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByIRD(IRD ird);
    }

    public class PaySlipManager(
        IPaySlipPersistance persistance,
        ILegislationService legislationService,
        IFormulas formulas) : IPaySlipManager
    {
        private readonly IPaySlipPersistance persistance = persistance;
        private readonly ILegislationService legislationService = legislationService;
        private readonly IFormulas formulas = formulas;

        public async Task<PaySlipRecordDto> CreatePaySlip(PaySlip paySlip)
        {
            TaxableIncomeTable table = await legislationService.GetTaxableIncomeTable();

            PaySlipRecord record = CreatePaySlipRecord(paySlip, table);

            PaySlipRecord addedRecord = await persistance.AddPaySlip(record);

            PaySlipRecordDto recordDto = ConvertPlaySlipRecord(addedRecord);

            return recordDto;
        }

        public async Task<PaySlipRecordDto> DeletePaySlip(string id)
        {
            PaySlipRecord addedRecord = await persistance.DeletePaySlip(id);

            PaySlipRecordDto recordDto = ConvertPlaySlipRecord(addedRecord);

            return recordDto;
        }

        public async Task<PaySlipRecordDto> GetPaySlip(string id)
        {
            PaySlipRecord addedRecord = await persistance.GetPaySlip(id);

            PaySlipRecordDto recordDto = ConvertPlaySlipRecord(addedRecord);

            return recordDto;
        }

        public async Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByDate(DateTime from, DateTime To)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByIRD(IRD ird)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<PaySlipRecordDto>> GetAllPaySlipsByName(string name)
        {
            throw new NotImplementedException();
        }

        private PaySlipRecord CreatePaySlipRecord(PaySlip paySlip, TaxableIncomeTable table)
        {
            throw new NotImplementedException();
        }

        private PaySlipRecordDto ConvertPlaySlipRecord(PaySlipRecord record)
        {
            throw new NotImplementedException();
        }
    }
}