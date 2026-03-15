using WebApplication4.Models.Book;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Models.Category
{
    public class CategoryEntity
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public virtual List<BookEntity> Books { get; set; }
    }
}
