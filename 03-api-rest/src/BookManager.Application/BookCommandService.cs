using BookManager.Application.Models;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;

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
                AuthorId = book.AuthorId ,

            };

            _bookDbContext.Books.Add(bookEntity);

            await _bookDbContext.SaveChangesAsync();

        }

        public async Task SaveChangesAsync(int id,BookModel book)
        {

            var exists =  _bookDbContext.Books.AnyAsync(x => x.Id == id).Result;

            if (exists == false)
            {
                throw new Exception("Libro no encontrado");
            }

            var bookEntity = new BookEntity

            {
                Title = book.Title,
                Description = book.Description,
                PublishedOn = book.PublishedOn,
                AuthorId = book.AuthorId,
                Id = id
            };


            if (book != null)
            {
                _bookDbContext.Books.Add(bookEntity);

                _bookDbContext.Books.Entry(bookEntity).State = EntityState.Modified;

                await _bookDbContext.SaveChangesAsync();
            }

        }

    }
}
