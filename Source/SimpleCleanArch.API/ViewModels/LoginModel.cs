namespace SimpleCleanArch.API.ViewModels
{
    public class LoginModel
    {
        public string UserName { get; set; } = "";
        public string PassWord { get; set; } = "";

        public bool Bearer { get; set; }
    }
}
