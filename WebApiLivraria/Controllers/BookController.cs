using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsShared.Helpers;
using ModelsShared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult> GetBook()
        {
            ResultModelList<Book> resultModel = new ResultModelList<Book>();

            var allBooks = await _uof.BookRepository.GetAsync();

            resultModel.Models = new List<Book>(allBooks);

            return Ok(resultModel);
        }

        [HttpGet]
        [Route("GetTopBooks")]
        public async Task<ActionResult> GetTopBooks()
        {
            ResultModelList<Book> resultModel = new ResultModelList<Book>();

            var allBooks = await _uof.BookRepository.GetAsync();

            resultModel.Models = new List<Book>(allBooks);

            if(resultModel.Models != null)
            {
                resultModel.SuccessMessage = "Operação concluída com sucesso";
            }
            else
            {
                resultModel.ErrorMessage = "Não encontramos nenhum livro";
            }

            return Ok(resultModel);
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
