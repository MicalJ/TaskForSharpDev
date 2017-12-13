using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAPI.DB.DbModels
{
    public class Actor
    {
        public Actor()
        {
            Movie = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MovieId { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
