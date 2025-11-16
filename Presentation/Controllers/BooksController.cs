using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers;
[ApiController]
[Route("api/books")]

public class BookController : ControllerBase
{
    private readonly IServiceManager _manager;

    public BookController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult GetAllBook()
    {
        try
        {
            var books = _manager.BookService.GetAllBooks(false);
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
            var book = _manager.BookService.GetOneBookById(id, false);
            return Ok(book);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        _manager.BookService.CreateOneBook(book);
        return Ok(book);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
    {
        _manager.BookService.DeleteOneBook(id, false);
        return NoContent();
    }
    [HttpPut("{id:int}")]
    public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,[FromBody] Book book) 
    {
        try
        {
            if (book is null)
                return BadRequest();

            _manager.BookService.UpdateOneBook(id,book,true);
            return NoContent();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
        

}

