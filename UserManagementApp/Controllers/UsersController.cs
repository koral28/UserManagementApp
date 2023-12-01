using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Models;
using UserManagementApp.Service;

namespace SupercomTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IManager _manager;
        public UsersController(IManager manager) 
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsersFromDB()
        {
            object res = _manager.GetAllUsersFromDB();
            if (res is string || res is null)
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
            if (res is string || res is null)
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
            if (res is string || res is null)
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
