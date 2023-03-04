using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using STUdemyKurs.Models;

namespace STUdemyKurs.Data
{
    public class SeedDataBase
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = File.ReadAllText("Data/users.json");
                var listOfUsers = JsonConvert.DeserializeObject<List<User>>(users);

                foreach (var user in listOfUsers)
                {
                    await userManager.CreateAsync(user, "SocialApp_123");
                }
            }
        }
    }
}
