using SalesPersonAPI.Domain.Entities;

namespace SalesPersonAPI.Storage.Repositories
{
    public interface ISalesPersonRegionXrefRepository
    {
        Task<int> CreateSalesPersonRegionXrefAsync(SalesPersonRegionXref salesPersonRegionXref);
        Task<IEnumerable<SalesPersonRegionXref>> GetSalesPersonRegionXrefsBySalesPersonIdAsync(int salesPersonId);
    }
}
