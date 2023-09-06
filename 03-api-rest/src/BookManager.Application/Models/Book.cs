using BookManager.Domain;


namespace BookManager.Application.Models
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedOn { get; set; } = new DateTime();
        public string Description { get; set; } = string.Empty;
        public Author Author { get; set; } = new();
    }
}
