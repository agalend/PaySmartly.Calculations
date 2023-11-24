using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations.Persistance
{
    public interface IPersistance
    {
        Task<Record> Create(PaySlip paySlip);
        Task<Record?> Get(string id);
        Task<Record?> Delete(string id);
    }

    public class Persistance : IPersistance
    {
        public Task<Record> Create(PaySlip paySlip)
        {
            throw new NotImplementedException();
        }

        public Task<Record?> Delete(string recordId)
        {
            throw new NotImplementedException();
        }

        public Task<Record?> Get(string recordId)
        {
            throw new NotImplementedException();
        }
    }
}