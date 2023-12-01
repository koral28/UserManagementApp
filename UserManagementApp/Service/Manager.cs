using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UserManagementApp.Models;

namespace UserManagementApp.Service
{
    public class Manager : ControllerBase
    {
        readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.json");
        public IActionResult GetAllUsersFromDB()
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("Users data file not found");
                }

                string jsonData = System.IO.File.ReadAllText(filePath);
                object deserialized = JsonConvert.DeserializeObject(jsonData);
                if (deserialized is JObject)
                {
                    var user = JsonConvert.DeserializeObject<UserModel>(jsonData);
                    return Ok(user);
                }
                else
                {
                    var users = JsonConvert.DeserializeObject<List<UserModel>>(jsonData);
                    return Ok(users);
                }


            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch users ", e);
            }
        }

        public IActionResult AddUserToDB([FromBody] UserModel newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest("User data is null");
                }

                string jsonData = JsonConvert.SerializeObject(newUser, Formatting.Indented);
                string existingData = System.IO.File.ReadAllText(filePath);
                List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(existingData) ?? new List<UserModel>();
                userList.Add(newUser);
                string updatedJsonData = JsonConvert.SerializeObject(userList, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, updatedJsonData);
                return Ok(newUser);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch users ", e);
            }
        }

        public IActionResult DeleteUserFromDB([FromBody] string phoneNumber)
        {
            try
            {
                string existingData = System.IO.File.ReadAllText(filePath);
                List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(existingData) ?? new List<UserModel>();
                UserModel userToRemove = userList.Find(u => u.Phone == phoneNumber);
                if (userToRemove != null)
                {
                    userList.Remove(userToRemove);
                    string updatedJsonData = JsonConvert.SerializeObject(userList, Formatting.Indented);
                    System.IO.File.WriteAllText(filePath, updatedJsonData);
                    return Ok(phoneNumber);
                }
                else
                {
                    return BadRequest($"User with phone {phoneNumber} not found.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch users ", e);
            }
        }
    }
}
