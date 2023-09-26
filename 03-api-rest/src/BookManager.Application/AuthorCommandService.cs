using BookManager.Application.Models;
using BookManager.Domain;

namespace BookManager.Application
{
    public class AuthorCommandService
    {
        private IBookDbContext _bookDbContext;

        public AuthorCommandService(IBookDbContext bookDbContext )
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<int> SaveChangesAsync(AuthorModel author)
        {
            var authorEntity = new AuthorEntity

            {
                Name = author.FirstName,
                LastName = author.LastName,
                Birth = author.Birth,
                CountryCode = author.CountryCode 
            };


            _bookDbContext.Authors.Add(authorEntity);

            await _bookDbContext.SaveChangesAsync();

            var books = new List<BookEntity>();

            if (author.Books != null)
            {
                foreach (var book in author.Books)
                {
                    if (author != null)
                    {
                        books.Add(new BookEntity{ AuthorId = authorEntity.Id, Title = book.Title, Description = book.Description, PublishedOn = book.PublishedOn });
                    }
                }

                foreach (var book in books)
                {
                    _bookDbContext.Books.Add(book);
                }

                await _bookDbContext.SaveChangesAsync();

            }


            return authorEntity.Id;

        }

    }
}
