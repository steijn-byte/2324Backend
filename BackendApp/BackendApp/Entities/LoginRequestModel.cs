namespace BackendApp.Entities
{
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginRequestModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
