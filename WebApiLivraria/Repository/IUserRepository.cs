using ModelsShared.Models;
using System.Threading.Tasks;

namespace WebApiLivraria.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<bool> UserIsInDb(User user);
    }
}
