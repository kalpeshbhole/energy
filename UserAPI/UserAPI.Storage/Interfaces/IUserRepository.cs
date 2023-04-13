using UserAPI.Domain.Entities;

namespace UserAPI.Storage.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByUserName(string userName);
    }
}
