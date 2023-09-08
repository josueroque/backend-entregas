using BookManager.Application;
using BookManager.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers;
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookCommandService _bookCommandService;
    private readonly BookQueryService _bookQueryService;

    public BookController(BookCommandService bookCommandService, BookQueryService bookQueryService)
    {
        _bookCommandService = bookCommandService;
        _bookQueryService = bookQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> SaveChangesAsync([FromBody] BookModel book)
    {
        try
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Description))
            {
                return BadRequest("Favor inserte todos los datos obligatorios");
            }

            await _bookCommandService.SaveChangesAsync(book);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al guardar!");  
        }
    }

    [HttpPut("{id:int}")]
    public async Task <IActionResult> SaveChangesAsync(int id,[FromBody] BookModel book)
    {
        try
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Description))
            {
                return BadRequest("Favor inserte todos los datos obligatorios");
            }

            await _bookCommandService.SaveChangesAsync(id, book);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al guardar!");
        }
    }

    [HttpGet]
    public async Task <IEnumerable<BookQueryModel>> GetAllBooksAsync()
    {
        var books = await _bookQueryService.GetAllBooksAsync();
        return books;
    }


}
