using StoreAPI.Domain.Models;

namespace StoreAPI.Engines.Interfaces
{
    public interface IUserEngine
    {
        Task<User> GetUserByIdAsync(int userId);
    }
}
