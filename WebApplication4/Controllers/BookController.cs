using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models.Book;
using WebApplication4.Models.Renting;
using WebApplication4.Models.Data;
using WebApplication4.Models.User;

namespace WebApplication4.Controllers
{
    public class BookController : Controller
    {
        private readonly LibDbContext DbContext;
        private readonly UserManager<AppUser> userManager;

        public BookController(LibDbContext dbContext, UserManager<AppUser> userManager)
        {
            DbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string title, string author, string isbn, Guid? category, string reset)
        {
            ViewBag.Categories = DbContext.Categories.ToList();

            var books = DbContext.Books.Include(b => b.Category).OrderByDescending(a => a.Isbn).ToList();

            if (!string.IsNullOrEmpty(reset))
            {
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty(title))
            {
                title = title.ToLower();
                books = books.Where(b => b.Title.ToLower().Contains(title)).ToList();
            }

            if (!string.IsNullOrEmpty(author))
            {
                author = author.ToLower();
                books = books.Where(b => b.AuthorFullname.ToLower().Contains(author)).ToList();
            }

            if (!string.IsNullOrEmpty(isbn))
            {
                books = books.Where(b => b.Isbn.Contains(isbn)).ToList();
            }

            if (category.HasValue && category.Value != Guid.Empty)
            {
                books = books.Where(b => b.CategoryId == category.Value).ToList();
            }
            foreach(var item in books)
            {
                if(item.BookCount <= 0)
                {
                    item.Status = Models.Book.Status.Niedostępna;
                }
                else
                {
                    item.Status = Models.Book.Status.Dostępna;
                }
            }
            await DbContext.SaveChangesAsync();

            return View(books);
        }
        [Authorize]
        public async Task<IActionResult> addToCart(Guid? id)
        {
            var currUser = await userManager.GetUserAsync(User);
            if (!User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            if (id == null)
            {
                return NotFound();
            }
            var bookEntity = DbContext.Books.Include(b => b.Category).Single(a => a.BookId == id);
            if (bookEntity == null)
            {
                return NotFound();
            }
            if (DbContext.Rents.Where(b => b.User.Equals(currUser)).Any(c => c.Book.Equals(bookEntity)))
            {
                return RedirectToAction("Index");
            }
            RentEntity rent = new RentEntity()
            {
                RentId = Guid.NewGuid(),
                User = currUser,
                Book = bookEntity
            };
            if(!(bookEntity.Status == Models.Book.Status.Niedostępna))
            {
                DbContext.Add(rent);
                await DbContext.SaveChangesAsync();
            }
            
            return RedirectToAction("Index");
        }
    }
}
