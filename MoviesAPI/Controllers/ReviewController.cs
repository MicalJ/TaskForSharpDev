using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DB.DbModels;
using MoviesAPI.Filters;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private IReviewsService _reviewService;

        public ReviewController(IReviewsService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Get all reviews
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var reviews = AutoMapper.Mapper.Map<List<ReviewResponse>>(_reviewService.GetAll());

            return Ok(reviews);
        }

        /// <summary>
        /// Get review by id
        /// </summary>
        /// <param name="reviewId">review id</param>
        /// <returns>Review if exist</returns>
        [HttpGet("{reviewId}")]
        public IActionResult Get(int reviewId)
        {
            Review review = _reviewService.GetById(reviewId);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(AutoMapper.Mapper.Map<ReviewResponse>(review));
        }

        /// <summary>
        /// Add new review
        /// </summary>
        /// <param name="review">Review</param>
        /// <returns></returns>
        [HttpPost]
        [MovieApiExceptionFilter]
        public IActionResult Post([FromBody]ReviewRequest review)
        {
            if (!_reviewService.AddNewReview(AutoMapper.Mapper.Map<Review>(review)))
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Update review in repositorium
        /// </summary>
        /// <returns></returns>
        [HttpPut("{reviewId}")]
        public IActionResult Put(int reviewId ,[FromBody]ReviewRequest reviewRequest)
        {
            var review = AutoMapper.Mapper.Map<Review>(reviewRequest);
            review.Id = reviewId;
            _reviewService.UpdateReview(review);

            return Ok();
        }

        /// <summary>
        /// Delete revie
        /// </summary>
        /// <param name="reviewId">review identifier</param>
        /// <returns></returns>
        [HttpDelete("{reviewId}")]
        public IActionResult Delete(int reviewId)
        {
            _reviewService.Remove(reviewId);
            return Ok();
        }
    }
}
