using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsShared.Models;
using System.Threading.Tasks;
using WebApiLivraria.BusinessLayer;
using WebApiLivraria.Helpers;
using WebApiLivraria.Repository;

namespace WebApiLivraria.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class AccountController : ControllerBase 
    {
        readonly AccountBusiness _accountBusiness;
        public AccountController(IUnityOfWork uof)
        {
            _accountBusiness = new AccountBusiness(uof);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {

            (int result, bool done, string message) = await _accountBusiness.AllowRegister(user);

            ResultModel<User> resultModel = new ResultModel<User>();

            if (done == true)
            {
                resultModel.SuccessMessage = "Usuário salvo com sucesso";
                return Ok(resultModel);
            }
            else
            {
                resultModel.ErrorMessage = message;
                return BadRequest(resultModel);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {

            (int result, bool done, string message) = await _accountBusiness.FindByUser(user);

            ResultModel<User> resultModel = new ResultModel<User>();

            if (done == true)
            {
                resultModel.SuccessMessage = message;
                return Ok(resultModel);
            }
            else
            {
                resultModel.ErrorMessage = message;
                return BadRequest(resultModel);
            }
        }
    }
}
