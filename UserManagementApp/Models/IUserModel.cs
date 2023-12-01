namespace UserManagementApp.Models
{
    public interface IUserModel
    {
        string AboutMe { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string TimeZone { get; set; }
        string UserName { get; set; }
        void SendEmail();
    }
}
