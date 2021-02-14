using System.Collections.Generic;
using System.Linq;
using ModelsShared.Models;

namespace WebApiLivraria.Repository
{
    public static class UserPatthernsRepository
    {
        public static UserPattherns Get(string username, string password)
        {
            var users = new List<UserPattherns>();
            users.Add(new UserPattherns {  UserPatthernsId = 1, Name = "batman", Password = "batman", Role = "manager" });
            users.Add(new UserPattherns { UserPatthernsId = 2, Name = "robin", Password = "robin", Role = "employee" });

            return users.Where(x => x.Name.ToLower() == username.ToLower() && x.Password == password.ToLower()).FirstOrDefault();
        }
    }
}
