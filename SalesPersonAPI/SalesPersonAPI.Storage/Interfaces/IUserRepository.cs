using SalesPersonAPI.Domain.Entities;

namespace SalesPersonAPI.Storage.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
    }
}
