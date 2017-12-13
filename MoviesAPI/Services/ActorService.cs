using MoviesAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.DB.DbModels;

namespace MoviesAPI.Services
{
    public class ActorService : IActorService
    {
        private readonly MoviesContext _context;

        public ActorService(MoviesContext context)
        {
            _context = context;
        }

        public bool AddActorsToMovie(Actor actor)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == actor.MovieId);

            if (movie == null)
            {
                return false;
            }

            movie.Actor.Add(actor);
            _context.SaveChanges();

            return true;
        }
    }
}
