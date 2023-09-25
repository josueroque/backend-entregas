using BookManager.Application.Models;
using BookManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           
            return authorEntity.Id;

        }

    }
}
