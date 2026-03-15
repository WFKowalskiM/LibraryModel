using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Models.Category;

namespace WebApplication4.Models.Book
{
    public class BookEntity
    {
        [Key]
        public Guid BookId { get; set; }
        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "Należy podać numer ISBN")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Numer ISBN powinien składać się z 13 cyfr")]
        [StringLength(13)]
        public string Isbn { get; set; }
        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Należy podać tytuł książki")]
        [StringLength(50)]
        public string Title { get; set; }
        [Display(Name = "Ilość dostępnych książek w bibliotece")]
        [Required(ErrorMessage = "Nalezy podać prawidłową ilość książek do dodania")]
        [Range(0, int.MaxValue, ErrorMessage = "Ilość książek nie może być ujemna")]
        public int BookCount { get; set; }
        public Status Status { get; set; }
        [Display(Name = "Ilość stron")]
        [Required(ErrorMessage = "Nalezy podać prawidłową ilość stron")]
        [Range(1, int.MaxValue, ErrorMessage = "Ilość stron nie może być mniejsza niż 1")]
        public int PageCount { get; set; }
        [Display(Name = "Imię i nazwisko autora")]
        [Required(ErrorMessage = "Należy podać imię i nazwisko autora")]
        [StringLength(50)]
        public string AuthorFullname { get; set; }
        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Należy podać kategorię książki")]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Kategoria")]
        public virtual CategoryEntity Category { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data publikacji")]
        [Required(ErrorMessage = "Należy podać datę publikacji książki")]
        public DateTime PublishDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
    }
}
