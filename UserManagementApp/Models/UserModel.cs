namespace UserManagementApp.Models
{
    public class UserModel : IUserModel
    {
        public string AboutMe { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string TimeZone { get; set; }
        public string UserName { get; set; }

        public void SendEmail() 
        {
            Console.WriteLine($"{FirstName} is  is Sending an email to E1@example.com");
        }
    }
}