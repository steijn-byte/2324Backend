using System.ComponentModel.DataAnnotations;

namespace BackendApp.Entities
{
    public class User
    {
        public string Username { get; set; }
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }

        public User()
        {

        }
    }
}
