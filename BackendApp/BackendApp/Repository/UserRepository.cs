using BackendApp.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using BackendApp.Interfaces;

namespace BackendApp.Repository
{
    public class UserRepository : WebappContext, IUserRepository
    {
        public UserRepository(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public User LoginUser(string name, string password)
        {
            User? user = null;
            try
            {
                Console.WriteLine("return fake user");
               // user = Users.FirstOrDefault(u => u.Username == name && u.Password == password);
                user.Username = name;
                user.Password = password;
                user.Email = "test";
                user.Id = Guid.NewGuid();
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                else
                {
                    return user;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error: {e.Message}");
                throw;
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                await Users.AddAsync(user);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error: {e.Message}");
                throw;
            }
        }
    }
}
