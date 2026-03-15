using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models.Book;
using WebApplication4.Models.Data;
using WebApplication4.Models.User;
using WebApplication4.Models.Renting;

namespace WebApplication4.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly LibDbContext DbContext;

        public CartController(LibDbContext context, UserManager<AppUser> userManager)
        {
            DbContext = context;
            this.userManager = userManager;
        }

        // GET: Basket
        public async Task<IActionResult> Index()
        {
            var currUser = await userManager.GetUserAsync(User);
            if (!User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            var libDbContext = DbContext.Rents.Include(b => b.Book).Include(a => a.Book.Category).Where(a => a.User.Equals(currUser)).OrderByDescending(c => c.Book.Isbn).ToList();
            //await libDbContext.ToListAsync()
            return View(libDbContext);
        }

        // GET: Basket/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || DbContext.Rents == null)
            {
                return NotFound();
            }

            var rentEntity = await DbContext.Rents
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.RentId == id);
            if (rentEntity == null)
            {
                return NotFound();
            }
            return View(rentEntity);
        }

        // POST: Basket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (DbContext.Rents == null)
            {
                return Problem("Entity set 'LibDbContext.Rents'  is null.");
            }
            if (!RentEntityExists(id))
            {
                return NotFound();
            }
            var rentEntity = await DbContext.Rents.FindAsync(id);
            if (rentEntity != null)
            {
                DbContext.Rents.Remove(rentEntity);
            }
            
            await DbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Rent()
        {
            var currUser = await userManager.GetUserAsync(User);
            if (DbContext.Rents == null)
            {
                return NotFound();
            }
            if(!DbContext.Rents.Any(b => b.User.Id == currUser.Id)) 
            {
                return Problem("Koszyk jest pusty");
            }
            var rentEntity = DbContext.Rents.Include(b => b.Book).ToList();
            if (rentEntity == null)
            {
                return NotFound();
            }
            foreach(var item in rentEntity)
            {
                item.Book.BookCount--;
                if(item.Book.BookCount <= 0)
                {
                    item.Book.Status = Models.Book.Status.Niedostępna;
                }
                DbContext.Remove(item);
            }

            await DbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentEntityExists(Guid id)
        {
          return (DbContext.Rents?.Any(e => e.RentId == id)).GetValueOrDefault();
        }
    }
}
