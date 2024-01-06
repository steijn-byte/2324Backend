namespace BackendApp.Entities
{
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginRequestModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
