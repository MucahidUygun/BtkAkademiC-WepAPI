using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Repositories.EFCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public BookController(IRepositoryManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult GetAllBook()
        {
            try
            {
                var books = _manager.Book.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id) 
        {
            try
            {
                var book = _manager.Book.GetOneBookById(id:id,trackChanges:false);
                return Ok(book);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOneBokk([FromBody] Book book)
        {
             _manager.Book.CreateOneBook(book);
            _manager.Save();
            return Ok(book);
        }
    }
}
