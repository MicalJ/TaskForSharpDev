using System.Collections.Generic;
using MoviesAPI.DB.DbModels;

namespace MoviesAPI.Interfaces
{
    public interface IReviewsService
    {
        List<Review> GetAll();

        Review GetById(int id);

        bool AddNewReview(Review review);

        void UpdateReview(Review review);

        void Remove(int reviewId);

        List<Review> GetByMovieId(int movieId);
        
        double ReturnAverageGrade(int movieId);
    }
}
