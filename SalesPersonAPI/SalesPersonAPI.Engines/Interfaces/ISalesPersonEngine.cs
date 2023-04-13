using SalesPersonAPI.Domain.Models;

namespace SalesPersonAPI.Engines.Interfaces
{
    public interface ISalesPersonEngine
    {
        Task<int> CreateSalesPersonAsync(SalesPerson salesPerson);
        Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync();
        Task<IEnumerable<SalesPerson>> GetSalesPersonsByStateIdAsync(int stateId);
        Task<SalesPerson> GetSalesPersonByIdAsync(int id);
    }
}
