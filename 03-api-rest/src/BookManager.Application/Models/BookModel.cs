
namespace BookManager.Application.Models
{
    public  class BookModel
    {
        public string Title { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }

    }
}
