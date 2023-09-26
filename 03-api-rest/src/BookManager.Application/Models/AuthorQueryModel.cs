
namespace BookManager.Application.Models
{
    public class AuthorQueryModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;    
        public DateTime Birth { get; set; } 
        public string CountryCode { get; set; } = string.Empty;
        public List<BookQueryModel> Books { get; set; } = new List<BookQueryModel>();
    }
}
