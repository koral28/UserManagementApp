using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UserManagementApp.Models;

namespace UserManagementApp.Service
{
    public class Manager : IManager
    {
        readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.json");
        private List<UserModel> listOfUsers = new List<UserModel>();    
        public object GetAllUsersFromDB()
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    return "Users data file not found";
                }

                string jsonData = System.IO.File.ReadAllText(filePath);
                object deserialized = JsonConvert.DeserializeObject(jsonData);
                if (deserialized is JObject)
                {
                    var user = JsonConvert.DeserializeObject<UserModel>(jsonData);
                    return user;
                }
                else
                {
                    var users = JsonConvert.DeserializeObject<List<UserModel>>(jsonData);
                    return users;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch users ", e);
            }
        }

        public object AddUserToDB([FromBody] UserModel newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return "User data is null";
                }

                string jsonData = JsonConvert.SerializeObject(newUser, Formatting.Indented);
                string existingData = System.IO.File.ReadAllText(filePath);
                List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(existingData) ?? new List<UserModel>();
                userList.Add(newUser);
                string updatedJsonData = JsonConvert.SerializeObject(userList, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, updatedJsonData);
                listOfUsers.Add(newUser);
                return newUser;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch users ", e);
            }
        }

        public object DeleteUserFromDB([FromBody] string phoneNumber)
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
                    listOfUsers.Remove(userToRemove);
                    return userToRemove;
                }
                else
                {
                    return $"User with phone {phoneNumber} not found.";
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch users ", e);
            }
        }
    }
}
