using BackendApp.Entities;

namespace BackendApp.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByName(string name);
    }
}
