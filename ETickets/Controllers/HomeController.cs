using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Diagnostics;
using System.Linq;

namespace ETickets.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext dbcontext = new ApplicationDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var movies = dbcontext.Movies
                .Include(e => e.Category)
                .Include(e => e.Cinema).Include(e => e.ActorMovies)
                .ToList();
            return View(movies);
        }



        public IActionResult Details(int movieId)
        {


            ViewBag.actors = dbcontext.ActorMovies
            .Where(e => e.MovieId == movieId)
            .Select(e => e.Actor)
            .ToList();

            var movie = dbcontext.Movies
                .Include(e => e.Cinema)
                .Include(e => e.Category)
                .FirstOrDefault(e => e.Id == movieId);

            if (movie == null)
            {
                return NotFound(); // Handle case when the movie is not found
            }

            return View(model: movie);
        }




        public IActionResult Search(string search)
        {
            var movie = dbcontext.Movies
                .Include(e => e.Cinema)
                .Include(e => e.Category)
                .Where(e => e.Name.Contains(search)).ToList();
            if (movie != null)
            {
                return View(movie);

            }
            return View("NotFoundPage");

        }

        public IActionResult NotFoundPage()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


