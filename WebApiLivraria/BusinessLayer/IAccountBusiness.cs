using ModelsShared.Models;
using System.Threading.Tasks;

namespace WebApiLivraria.BusinessLayer
{
    public interface IAccountBusiness
    {
        Task<(int, bool, string)> AllowRegister(User user);

        Task<(int, bool, string)> FindByUser(User user);
    }
}
