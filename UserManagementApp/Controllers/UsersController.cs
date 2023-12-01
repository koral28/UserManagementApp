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
            object res = _manager.GetAllUsersFromDB();
            if (res is string)
            {
                return NotFound(res);
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPost]
        [Route("addNewUser")]
        public IActionResult AddUserToDB([FromBody] UserModel newUser)
        {
            object res = _manager.AddUserToDB(newUser);
            if (res is string)
            {
                return BadRequest(res);
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteUserFromDB([FromBody] string phoneNumber)
        {
            object res = _manager.DeleteUserFromDB(phoneNumber);
            if (res is string)
            {
                return BadRequest(res);
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
