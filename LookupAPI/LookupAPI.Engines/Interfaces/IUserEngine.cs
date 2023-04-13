using LookupAPI.Domain.Models;

namespace LookupAPI.Engines.Interfaces
{
    public interface IUserEngine
    {
        Task<User> GetUserByIdAsync(int userId);
    }
}
