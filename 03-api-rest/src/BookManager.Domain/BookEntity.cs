
using System.ComponentModel.DataAnnotations;


namespace BookManager.Domain
{
    public class BookEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime PublishedOn { get; set; } = new DateTime();
        public string Description { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; } 


    }
}
