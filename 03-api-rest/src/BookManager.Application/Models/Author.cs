
namespace BookManager.Application.Models
{
    public class Author
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public string CountryCode { get; set; } 
        public List<Book>? Books { get; set; } 
    }
}
