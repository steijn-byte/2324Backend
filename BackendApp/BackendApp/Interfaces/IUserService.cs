using BackendApp.Entities;

namespace BackendApp.Interfaces
{
    public interface IUserService
    {
        User LoginUser(string name, string password);
        Task<bool> RegisterUser(User user);
    }
}
