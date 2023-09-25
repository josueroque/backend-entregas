using BookManager.Application;
using BookManager.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers;
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private AuthorCommandService _authorCommandService;
    private AuthorQueryService _authorQueryService;

    public AuthorController(AuthorCommandService authorCommandService, AuthorQueryService authorQueryService)
    {
        _authorCommandService = authorCommandService;
        _authorQueryService = authorQueryService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthorAsync(int id)
    {
        var author = await _authorQueryService.GetAuthorAsync(id);

        if (string.IsNullOrEmpty(author.FirstName))
        {
            return NotFound();
        }

        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> SaveChangesAsync ([FromBody]AuthorModel author)
    {
        try 
        { 
        if (author.FirstName == null || author.LastName == null || author.CountryCode == null) 
        {
            return BadRequest("Favor inserte todos los datos obligatorios");
        }
        
            var id = await _authorCommandService.SaveChangesAsync(author);
        
            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al guardar!");
        }
    }


}
