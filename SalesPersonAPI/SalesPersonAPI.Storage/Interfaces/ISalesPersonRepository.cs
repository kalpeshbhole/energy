using SalesPersonAPI.Domain.Entities;

namespace SalesPersonAPI.Storage.Interfaces
{
    public interface ISalesPersonRepository
    {
        Task<int> CreateSalesPersonAsync(SalesPerson salesPerson);
        Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync();
        Task<SalesPerson> GetSalesPersonByIdAsync(int id);
        Task<IEnumerable<SalesPerson>> GetSalesPersonsByStateIdAsync(int stateId);
    }
}
