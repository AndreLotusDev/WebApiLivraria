using System.Collections.Generic;
using System.Linq;
using ModelsShared.Models;
using WebApiLivraria.Data;

namespace WebApiLivraria.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User {  UserId = 1, Name = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { UserId = 2, Name = "robin", Password = "robin", Role = "employee" });

            return users.Where(x => x.Name.ToLower() == username.ToLower() && x.Password == password.ToLower()).FirstOrDefault();
        }
    }
}
