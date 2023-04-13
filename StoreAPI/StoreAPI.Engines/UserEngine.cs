using AutoMapper;
using StoreAPI.Domain.Models;
using StoreAPI.Engines.Interfaces;
using StoreAPI.Storage.Interfaces;

namespace StoreAPI.Engines
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