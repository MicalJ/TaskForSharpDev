using System.Collections.Generic;

namespace MoviesAPI.DB.DbModels
{
    public class Movie
    {
        public Movie()
        {
            Actor = new HashSet<Actor>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Actor> Actor { get; set; }
    }
}
