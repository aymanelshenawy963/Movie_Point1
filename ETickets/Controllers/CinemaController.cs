using ETickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        ApplicationDbContext dbcontext = new();

        public IActionResult Index()
        {
            var cinemas = dbcontext.Cinemas.ToList();

            return View(cinemas);
        }

        public IActionResult Details(String cinemaName)
        {
            var movies = dbcontext.Movies
                .Include(e => e.Category)
                .Include(e => e.Cinema).Where(e => e.Cinema.Name == cinemaName)
                .ToList();
            return View(movies);
        }
    }
}
