using Microsoft.AspNetCore.Mvc;

namespace SupercomTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("getAllUsers")]
        public void GetAllVehiclesFromDB()
        {

        }
    }
}
