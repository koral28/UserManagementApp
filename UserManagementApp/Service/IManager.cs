using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Models;

namespace UserManagementApp.Service
{
    public interface IManager
    {
        IActionResult GetAllUsersFromDB();
        IActionResult AddUserToDB([FromBody] UserModel newUser);
        IActionResult DeleteUserFromDB([FromBody] string phoneNumber);
    }
}
