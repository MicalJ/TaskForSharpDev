using System.Collections.Generic;
using MoviesAPI.DB.DbModels;

namespace MoviesAPI.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAll();

        Movie GetById(int id);

        void AddNewMovie(Movie movie);

        void UpdateMovie(Movie movie);

        void Remove(int movieId);

        object Search(string search = null);
    }
}
