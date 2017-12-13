using System.Collections.Generic;
using System.Linq;
using MoviesAPI.DB.DbModels;
using MoviesAPI.Interfaces;

namespace MoviesAPI.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MoviesContext _context;

        public MoviesService(MoviesContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Where(m => m.Id == id).SingleOrDefault();
        }

        public void AddNewMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int movieId)
        {
            Movie movie = GetById(movieId);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public object Search(string search)
        {
            var movies = _context.Movies.Where(w => (search == null ||
                w.Year.ToString().Contains(search) ||
                w.Title.ToLower().Contains(search.ToLower()))).Select(s => new { s.Title, s.Year }).ToList();

            return movies;
        }
    }
}
