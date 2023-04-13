using AutoMapper;
using SalesPersonAPI.Domain.Models;
using SalesPersonAPI.Engines.Interfaces;
using SalesPersonAPI.Storage.Interfaces;

namespace SalesPersonAPI.Engines
{
    internal class UserEngine : IUserEngine
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserEngine(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

       
        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<User>(user);
        }

    }
}