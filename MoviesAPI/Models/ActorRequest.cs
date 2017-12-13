using MoviesAPI.DB.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class ActorRequest
    {
        public int MovieId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
