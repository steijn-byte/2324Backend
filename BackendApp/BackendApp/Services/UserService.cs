using BackendApp.Entities;
using BackendApp.Interfaces;

namespace BackendApp.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetUserByName(string name)
        {
            return userRepository.GetUserByName(name);
        }
    }
}
