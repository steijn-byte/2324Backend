using BackendApp.Entities;
using BackendApp.Interfaces;

namespace BackendApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<bool> RegisterUser(User user)
        {
            return await userRepository.RegisterUser(user);
        }
        public User GetUserByName(string name)
        {
            return userRepository.GetUserByName(name);
        }
    }
}
