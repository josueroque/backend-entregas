using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AuthorEntity Author { get; set; } = new();
        public int AuthorId { get; set; } 

    }
}
