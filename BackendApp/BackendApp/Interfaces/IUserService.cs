using BackendApp.Entities;

namespace BackendApp.Interfaces
{
    public interface IUserService
    {
        User GetUserByName(string name);
    }
}
