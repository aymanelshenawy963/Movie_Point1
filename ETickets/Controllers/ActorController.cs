using ETickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class ActorController : Controller
    {
        ApplicationDbContext dbContext= new ApplicationDbContext();
        public IActionResult Index(int actorId)
        {
             
            return View(dbContext.Actors.FirstOrDefault(e => e.Id == actorId));
        }
    }
}
