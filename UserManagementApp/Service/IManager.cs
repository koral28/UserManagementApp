using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Models;

namespace UserManagementApp.Service
{
    public interface IManager
    {
        object GetAllUsersFromDB();
        object AddUserToDB([FromBody] UserModel newUser);
        object DeleteUserFromDB([FromBody] string phoneNumber);
    }
}
