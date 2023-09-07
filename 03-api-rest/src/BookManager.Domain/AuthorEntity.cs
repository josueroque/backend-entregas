
using System.ComponentModel.DataAnnotations;

namespace BookManager.Domain
{
    public class AuthorEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(80)]
        public string LastName { get; set; } = string.Empty;
        public DateTime Birth { get; set; } = new DateTime();
        [MaxLength(2)]
        public string CountryCode { get; set; } = string.Empty;
        public List<BookEntity> Books { get; set; } = null!;

    }
}
