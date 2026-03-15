using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication4.Models;
using WebApplication4.Models.Book;
using WebApplication4.Models.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibDbContext DbContext;

        public HomeController(LibDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var books = DbContext.Books.Include(b => b.Category).OrderByDescending(a => a.CreatedOn).Take(10).ToList();
            foreach (var item in books)
            {
                if (item.BookCount <= 0)
                {
                    item.Status = Models.Book.Status.Niedostępna;
                }
                else
                {
                    item.Status = Models.Book.Status.Dostępna;
                }
            }
            await DbContext.SaveChangesAsync();
            return View(books) ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}