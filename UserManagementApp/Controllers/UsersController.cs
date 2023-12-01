using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Models;
using UserManagementApp.Service;

namespace SupercomTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly Manager _manager;
        public UsersController(Manager manager) 
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsersFromDB()
        {
            return _manager.GetAllUsersFromDB();
        }

        [HttpPost]
        [Route("addNewUser")]
        public IActionResult AddUserToDB([FromBody] UserModel newUser)
        {
            return _manager.AddUserToDB(newUser);
        }

        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteUserFromDB([FromBody] string phoneNumber)
        {
            return _manager.DeleteUserFromDB(phoneNumber);
        }
    }
}
