using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiLivraria.Helpers;
using WebApiLivraria.Models;
using WebApiLivraria.Repository;

namespace WebApiLivraria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnityOfWork _uof;
        public BookController(IUnityOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBook()
        {
            return await _uof.BookRepository.GetAsync();
        }

        [Route("RegisterBook")]
        [HttpPost]
        public async Task<ActionResult> RegisterBook(Book bookToRegister)
        {
            //Checar se ele ja existe
            //Cadastro
            _uof.BookRepository.Add(bookToRegister);
            (int result, bool validate, string message) = await _uof.BookRepository.SaveAsync();

            ResultModel resultModel = new ResultModel();

            if(validate == true)
            {
                resultModel.SuccessMessage = message;
                return Ok(resultModel);
            }
            else
            {
                resultModel.ErrorMessage = message;
                return BadRequest();
            }
        }

        [Route("DeleteBook")]
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(Book bookToDelete)
        {
            _uof.BookRepository.Delete(bookToDelete);

            (int result, bool validate, string message) = await _uof.BookRepository.SaveAsync();

            ResultModel resultModel = new ResultModel();

            if (validate == true)
            {
                resultModel.SuccessMessage = message;
                return Ok(resultModel);
            }
            else
            {
                resultModel.ErrorMessage = message;
                return BadRequest();
            }
        }
    }
}
