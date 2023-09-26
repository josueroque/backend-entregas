
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

        public async Task<IEnumerable<BookQueryModel>> GetAllBooksAsync()
        {
            var books = await _bookDbContext
                .Books
                .Select(b => new BookQueryModel {  Title = b.Title, Description = b.Description, PublishedOn = b.PublishedOn.ToString(("s")), AuthorName = $"{b.Author.Name} {b.Author.LastName}"})
                .ToListAsync();

            return books;
        }


    }
}
