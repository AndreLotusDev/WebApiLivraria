using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiLivraria.Data;
using WebApiLivraria.Repository;

namespace WebApiLivraria.Controllers
{
    public class AccountController : ControllerBase
    {
        private SignInManager<UsuarioContext> _signManager;
        private UserManager<UsuarioContext> _userManager;
        private readonly IUnityOfWork _uof;

        public AccountController(UserManager<UsuarioContext> userManager, SignInManager<UsuarioContext> signManager, IUnityOfWork uof)
        {
            _userManager = userManager;
            _signManager = signManager;
            _uof = uof;
        }
    }
}
