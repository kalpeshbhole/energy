using SalesPersonAPI.Domain.Models;

namespace SalesPersonAPI.Engines.Interfaces
{
    public interface IUserEngine
    {
        Task<User> GetUserByIdAsync(int userId);
    }
}
