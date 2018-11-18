namespace VILIB.Helpers
{
    public class LoginEventArgs
    {
        public bool IsSuccessful { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class FrontendUser
    {
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}