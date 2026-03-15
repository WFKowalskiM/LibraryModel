using Microsoft.EntityFrameworkCore;
using System;
using WebApplication4.Models.Data;
using WebApplication4.Models.Category;

namespace WebApplication4.Models.Book
{
    public class BookStorage
    {

        private readonly LibDbContext DbContext;
        public BookStorage(LibDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public List<BookEntity> fetchNewBooks { get; set; }
    }
}
