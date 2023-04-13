using StoreAPI.Domain.Entities;

namespace StoreAPI.Storage.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
    }
}
