﻿
using BookManager.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application
{
    public class BookQueryService
    {
        private readonly IBookDbContext _bookDbContext;

        public BookQueryService(IBookDbContext bookDbContext) 
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<IEnumerable<BookQueryModel>> GetAllBooksAsync(BookParameters bookParameters)
        {
            var books = await _bookDbContext
                .Books
                .Select(b => new BookQueryModel {  Title = b.Title, Description = b.Description, PublishedOn = b.PublishedOn.ToString(("s")), AuthorName = $"{b.Author.Name} {b.Author.LastName}"})
                .ToListAsync();

            if (bookParameters?.Title != null)
            {
                books = books.Where(b => b.Title == bookParameters.Title).ToList();
            }

            if (bookParameters?.Author != null)
            {
                books = books.Where(b => b.AuthorName == bookParameters.Author).ToList();
            }

            return books;
        }


    }
}
