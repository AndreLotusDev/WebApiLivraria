using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLivraria.Helpers;
using WebApiLivraria.Repository;

namespace WebApiLivraria.Controllers
{
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IUnityOfWork _uof;

        public RoleController(RoleManager<IdentityRole> roleManager, IUnityOfWork uof)
        {
            _roleManager = roleManager;
            _uof = uof;
        }

        [Route("GetRoles")]
        [HttpGet]
        public async Task<ActionResult> GetRoles()
        {
            var result = _roleManager.Roles.ToList();
            return Ok(result);
        }

        [Route("CreateRole")]
        [HttpPost]
        public async Task<ActionResult> CreateRole(RoleModel roleModel)
        {
            ResultModel resultModel = new ResultModel();

            try
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleModel.Name);

                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleModel.Name));
                }

                resultModel.SuccessMessage = "Operação realizada com sucesso";
                return Ok(resultModel);
            }
            catch (Exception ex)
            {
                resultModel.ErrorMessage = ex.Message;
                return BadRequest();
            }

        }
    }
}
