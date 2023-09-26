
using BookManager.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application
{
    public class AuthorQueryService
    {
        private readonly IBookDbContext _bookDbContext;

        public AuthorQueryService(IBookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<AuthorQueryModel> GetAuthorAsync(int id)
        {
            var author = await _bookDbContext
                .Authors
                .Where(a => id == a.Id )
                .Select(a => new AuthorQueryModel { FirstName = a.Name, LastName = a.LastName, CountryCode = a.CountryCode, Books = new List<BookQueryModel>() , Birth = a.Birth })
                .FirstOrDefaultAsync();

            var books = await _bookDbContext
                .Authors
                .Where(a => id == a.Id)
                .Select(a => a.Books)
                .FirstOrDefaultAsync();

            if (books != null) { 
                foreach (var book in books) {
                    if (author != null) {
                        author.Books.Add(new BookQueryModel { Title = book.Title,  Description = book.Description, PublishedOn = book.PublishedOn.ToString(("s")), AuthorName = $"{author.FirstName} {author.LastName}"});
                    }
                }
            }

            return author ?? new AuthorQueryModel();
        }


    }
}
