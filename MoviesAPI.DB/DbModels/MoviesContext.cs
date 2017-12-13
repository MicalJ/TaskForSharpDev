using System.Data.Entity;

namespace MoviesAPI.DB.DbModels
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base(@"Data Source=PREDATOR\SQLEXPRESS;Initial Catalog=MoviesAPIDb;Integrated Security=True")
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
