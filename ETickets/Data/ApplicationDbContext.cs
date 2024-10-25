using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Actor> Actors {  get; set; }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Cinema> Cinemas {  get; set; }
        public DbSet<Movie> Movies {  get; set; }
        public DbSet<ActorMovie> ActorMovies {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connection = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
               optionsBuilder.UseSqlServer(connection);
        }
    }
}
