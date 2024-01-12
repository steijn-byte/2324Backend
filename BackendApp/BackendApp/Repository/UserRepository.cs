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
        public User GetUserByName(string name)
        {
            User? user = null;
            try
            {
                user = Users.FirstOrDefault(u => u.Username == name);
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
    }
}
