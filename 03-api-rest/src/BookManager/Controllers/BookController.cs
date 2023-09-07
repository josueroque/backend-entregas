﻿using BookManager.Application;
using BookManager.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers;
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private BookCommandService _bookCommandService;
    public BookController(BookCommandService bookCommandService)
    {
        _bookCommandService = bookCommandService;
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

}
