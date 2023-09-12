

namespace BookManager.Application.Models
{
    public class BookQueryModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PublishedOn { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;

    }
}
