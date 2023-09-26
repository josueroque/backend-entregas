
namespace BookManager.Application.Models
{
    public class AuthorModel
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public DateTime Birth { get; set; }
        public string CountryCode { get; set; }   
        public List<BookModel>? Books { get; set; } 
    }
}
