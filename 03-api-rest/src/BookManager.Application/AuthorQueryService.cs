
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

        public async Task<AuthorModel> GetAuthorAsync(int id)
        {
            var author = await _bookDbContext
                .Authors
                .Where(a => id == a.Id )
                .Select(a => new AuthorModel { FirstName = a.Name, LastName = a.LastName, CountryCode = a.CountryCode })
                .FirstOrDefaultAsync();

            return author ?? new AuthorModel();
        }


    }
}
