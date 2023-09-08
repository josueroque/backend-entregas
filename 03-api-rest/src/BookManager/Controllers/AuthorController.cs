using BookManager.Application;
using BookManager.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers;
[Route("api/[controller]")]
public class AuthorController:ControllerBase
{
    private AuthorCommandService _authorCommandService;
    public AuthorController(AuthorCommandService authorCommandService)
    {
        _authorCommandService = authorCommandService;
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
        await _authorCommandService.SaveChangesAsync(author);
        return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al guardar!");
        }
    }


}
