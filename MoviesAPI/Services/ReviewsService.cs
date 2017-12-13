using System.Collections.Generic;
using System.Linq;
using MoviesAPI.DB.DbModels;
using MoviesAPI.Interfaces;
using MoviesAPI.Common;

namespace MoviesAPI.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly MoviesContext _context;

        public ReviewsService(MoviesContext context)
        {
            _context = context;
        }
        
        public List<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review GetById(int id)
        {
            return _context.Reviews.Find(id);
        }

        public bool AddNewReview(Review review)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == review.MovieId);
            if (movie==null)
            {
                return false;   
            }

            movie.Reviews.Add(review);
            _context.SaveChanges();

            return true;
        }

        public void UpdateReview(Review review)
        {
            _context.Entry(review).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int reviewId)
        {
            Review review = GetById(reviewId);
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }

        public List<Review> GetByMovieId(int movieId)
        {
            var movie = _context.Movies.Where(m => m.Id == movieId).First();
            return movie.Reviews.ToList();
        }

        public double ReturnAverageGrade(int movieId)
        {
            var averageGrade = _context.Reviews.Where(w => w.MovieId == movieId).Average(a => a.Rate);

            return averageGrade;
        }
    }
}
