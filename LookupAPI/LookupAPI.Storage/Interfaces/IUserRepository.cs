using LookupAPI.Domain.Entities;

namespace LookupAPI.Storage.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
    }
}
