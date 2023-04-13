using UserAPI.Domain.Models;

namespace UserAPI.Engines.Interfaces
{
    public interface IUserEngine
    {
        Task<User> AuthenticateAsync(string userName, string password);
        Task<User> CreateAsync(User user, string password);
        Task<User> GetUserByIdAsync(int userId);
    }
}
