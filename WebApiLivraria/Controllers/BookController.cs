using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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


    }
}
