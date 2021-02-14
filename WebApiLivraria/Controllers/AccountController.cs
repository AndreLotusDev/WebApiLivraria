using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsShared.Models;
using System.Threading.Tasks;
using WebApiLivraria.Data;
using WebApiLivraria.Helpers;
using WebApiLivraria.Repository;

namespace WebApiLivraria.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUnityOfWork _uof;

        public AccountController(IUnityOfWork uof)
        {
            _uof = uof;
        }

        [HttpPost]
        [Route("CreateAccount")]
        public dynamic Create([FromBody] User user)
        {
            user.Name = HashTranslate.sha256(user.Name);
            user.Password = HashTranslate.sha256(user.Password);
            _uof.UserRepository.Add(user);

            _uof.Commit();

            return Ok();
        }
    }
}
