using Microsoft.AspNetCore.Mvc;
using ModelsShared.Helpers;
using ModelsShared.Models;
using System.Linq;
using WebApiLivraria.Repository;

namespace WebApiLivraria.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnityOfWork _uof;
        public CategoriesController(IUnityOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            var prepareList = _uof.CategoriesRepository.Get();
            ResultModelList<Categories> resultModel = new ResultModelList<Categories>();

            resultModel.Models = prepareList.ToList();

            if(resultModel.Models != null)
                return Ok(resultModel);
            else
            {
                resultModel.ErrorMessage = "Houve erro ao processar sua solicitação";
                return BadRequest(resultModel);
            }
        }
    }
}
