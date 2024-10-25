using ETickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext dbcontext = new();
        public IActionResult Index()
        {
            var categories = dbcontext.Categories.ToList();
            return View(categories);
        }

        public IActionResult Details(string categoryName)
        { 

            var movies = dbcontext.Movies
                .Include(e => e.Category)
                .Include(e => e.Cinema)
                .Include(e => e.ActorMovies)
               .Where(e=>e.Category.Name== categoryName)
                .ToList();
            return View(movies);
        }
    }
}
