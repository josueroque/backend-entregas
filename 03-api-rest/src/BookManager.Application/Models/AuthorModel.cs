
namespace BookManager.Application.Models
{
    public class AuthorModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birth { get; set; }
        public string CountryCode { get; set; } = string.Empty;  
        public List<BookModel>? Books { get; set; } 
    }
}
