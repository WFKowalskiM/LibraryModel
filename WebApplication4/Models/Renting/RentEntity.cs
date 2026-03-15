using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Models.Book;
using WebApplication4.Models.User;

namespace WebApplication4.Models.Renting
{
    public class RentEntity
    {
        [Key]
        [Required]
        public Guid RentId { get; set; }
        public BookEntity Book { get; set; }
        public AppUser User { get; set; }
    }
}
