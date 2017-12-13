using MoviesAPI.DB.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Interfaces
{
    public interface IActorService
    {
        bool AddActorsToMovie(Actor actor);
    }
}
