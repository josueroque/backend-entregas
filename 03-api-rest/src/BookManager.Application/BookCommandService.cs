using BookManager.Application.Models;
using BookManager.Domain;

namespace BookManager.Application
{
    public class BookCommandService
    {
        private readonly IBookDbContext _bookDbContext;

        public BookCommandService(IBookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task SaveChangesAsync(BookModel book)
        {
            var bookEntity = new BookEntity

            {
                Title = book.Title,
                Description = book.Description,
                PublishedOn = book.PublishedOn,
                AuthorId = book.AuthorId,

            };

            _bookDbContext.Books.Add(bookEntity);

            await _bookDbContext.SaveChangesAsync();

        }

    }
}
