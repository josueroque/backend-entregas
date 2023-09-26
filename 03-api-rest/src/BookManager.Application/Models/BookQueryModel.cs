

namespace BookManager.Application.Models
{
    public class BookQueryModel
    {
        public string Title { get; set; } = string.Empty;
        public string? PublishedOn { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string? AuthorName { get; set; } 

    }
}
