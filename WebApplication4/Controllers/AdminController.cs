using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Models.Book;
using WebApplication4.Models.Category;
using WebApplication4.Models.Data;
using WebApplication4.Models.User;

namespace WebApplication4.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly LibDbContext DbContext;

        private readonly UserManager<AppUser> userManager;

        public AdminController(LibDbContext dbContext, UserManager<AppUser> userManager)
        {
            DbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }
            return View();
        }

        public async Task<IActionResult> ManageUsers()
        {
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }

            var users = userManager.Users.OrderBy(u => u.Status).ToList();

            ViewBag.IsEmployee = currUser.Role == Role.Employee;

            return View(users);
        }

        public async Task<IActionResult> ManageBooks()
        {
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }
            var books = DbContext.Books.Include(b => b.Category).OrderByDescending(b => b.Isbn).ToList();
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(string userId, string newStatus, string newRole)
        {
            var currUser = await userManager.GetUserAsync(User);

            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }

            var userToChange = await userManager.FindByIdAsync(userId);

            if (userToChange == null)
            {
                return NotFound();
            }

            if (currUser.Role == Role.Employee)
            {
                if (userToChange.Role == Role.Admin)
                {
                    return Forbid();
                }

                Enum.TryParse(newStatus, out Models.User.Status status);
                userToChange.Status = status;
            }
            else
            {
                Enum.TryParse(newStatus, out Models.User.Status status);
                userToChange.Status = status;

                Enum.TryParse(newRole, out Models.User.Role role);
                userToChange.Role = role;
            }

            await userManager.UpdateAsync(userToChange);

            return RedirectToAction("ManageUsers");
        }


        public async Task<IActionResult> CreateBook()
        {
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }
            ViewBag.Categories = new SelectList(DbContext.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook([Bind("BookId,PublishDate,Isbn,Title,BookCount,Status,PageCount,AuthorFullname,CategoryId")] BookEntity bookEntity)
        {
            ModelState.Remove("Category");
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }
            ViewBag.Categories = new SelectList(DbContext.Categories, "CategoryId", "Name");
            if (ModelState.IsValid)
            {
                bookEntity.BookId = Guid.NewGuid();
                bookEntity.CreatedOn = DateTime.Now;
                if (bookEntity.BookCount <= 0)
                {
                    bookEntity.Status = Models.Book.Status.Niedostępna;
                }
                DbContext.Add(bookEntity);
                await DbContext.SaveChangesAsync();
                return RedirectToAction(nameof(ManageBooks));
            }
            return View(bookEntity);
        }

        public async Task<IActionResult> DeleteBook(Guid? id)
        {
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }
            if (id == null)
            {
                return NotFound();
            }

            var bookEntity = await DbContext.Books
                .Include(b => b.Category)   
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            return View(bookEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }
            var bookEntity = await DbContext.Books.FindAsync(id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            DbContext.Books.Remove(bookEntity);
            await DbContext.SaveChangesAsync();

            return RedirectToAction(nameof(ManageBooks));
        }

        public async Task<IActionResult> EditBook(Guid? id)
        {
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }
            if (id == null)
            {
                return NotFound();
            }

            var bookEntity = await DbContext.Books.FindAsync(id);
            if (bookEntity == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(DbContext.Categories, "CategoryId", "Name");
            return View(bookEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(Guid id, [Bind("BookId,Isbn,Title,BookCount,Status,PageCount,AuthorFullname,CategoryId,PublishDate,CreatedOn")] BookEntity bookEntity)
        {
            ModelState.Remove("Category");
            var currUser = await userManager.GetUserAsync(User);
            if (currUser.Role != Role.Admin && currUser.Role != Role.Employee)
            {
                return Forbid();
            }
            if (id != bookEntity.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var originalCreatedOn = DbContext.Books.AsNoTracking().Where(b => b.BookId == id).Select(b => b.CreatedOn).FirstOrDefault();
                    bookEntity.CreatedOn = originalCreatedOn;

                    bookEntity.Category = DbContext.Categories.FirstOrDefault(c => c.CategoryId == bookEntity.CategoryId);
                    DbContext.Update(bookEntity);
                    if (bookEntity.BookCount <= 0) 
                    {
                        bookEntity.Status = Models.Book.Status.Niedostępna;
                    }
                    await DbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookEntityExists(bookEntity.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ManageBooks));
            }
            ViewBag.Categories = new SelectList(DbContext.Categories, "CategoryId", "Name");
            return View(bookEntity);
        }

        private bool BookEntityExists(Guid id)
        {
            return DbContext.Books.Any(e => e.BookId == id);
        }
    }
}
