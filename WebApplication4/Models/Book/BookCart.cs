using WebApplication4.Models.Data;

namespace WebApplication4.Models.Book
{
    public class BookCart
    {

            private readonly LibDbContext DbContext;
            public BookCart(LibDbContext DbContext)
            {
                this.DbContext = DbContext;
            }

            public List<BookEntity> bookCart { get; set; }
    }
}
