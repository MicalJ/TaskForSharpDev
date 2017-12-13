using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DB.DbModels;
using MoviesAPI.Filters;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Services;
using System.Collections.Generic;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private IMoviesService _moviesService;
        private readonly IReviewsService reviewsService;
        
        public MovieController(IMoviesService moviesService, IReviewsService reviewsService)
        {
            _moviesService = moviesService;
            this.reviewsService = reviewsService;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns>List of movies</returns>
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = AutoMapper.Mapper.Map<List<MovieResponse>>(_moviesService.GetAll());

            return Ok(movies);
        }

        /// <summary>
        /// Get movie by id
        /// </summary>
        /// <param name="movieId">movie identifier</param>
        /// <returns>Movie if found</returns>
        [HttpGet("{movieId}")]
        [ExecutionTime]
        public IActionResult Get(int movieId)
        {
            Movie movie = _moviesService.GetById(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(AutoMapper.Mapper.Map<MovieResponse>(movie));
        }

        /// <summary>
        /// Add new movie to repositorium
        /// </summary>
        /// <param name="movie">new movie</param>
        /// <returns></returns>
        [HttpPost]
        [ModelValidationAttribute]
        public IActionResult Post([FromBody]MovieRequest movie)
        {
            _moviesService.AddNewMovie(AutoMapper.Mapper.Map<Movie>(movie));

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="movieRequest"></param>
        /// <returns></returns>
        [HttpPut("{movieId}")]
        public IActionResult Put(int movieId, [FromBody]MovieRequest movieRequest)
        {
            var movie = AutoMapper.Mapper.Map<Movie>(movieRequest);
            movie.Id = movieId;
            _moviesService.UpdateMovie(movie);
            return Ok();
        }

        /// <summary>
        /// Delete movie from repositorium
        /// </summary>
        /// <param name="movieId">movie identifier</param>
        /// <returns></returns>
        [HttpDelete("{movieId}")]
        public IActionResult Delete(int movieId)
        {
            _moviesService.Remove(movieId);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet("{movieId}/Reviews")]
        public IActionResult GetReviews(int movieId)
        {
            var reviews = reviewsService.GetByMovieId(movieId);
            if (reviews==null)
            {
                return NotFound();
            }

            return Ok(AutoMapper.Mapper.Map<List<ReviewResponse>>(reviews));
        }

        /// <summary>
        /// Get Average Grade
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
       [HttpGet("{movieId}/AverageGrade")]
       public IActionResult GetAverageGrade(int movieId)
        {
             var result = reviewsService.ReturnAverageGrade(movieId);

            return Ok(result);
        }
        
        /// <summary>
        /// Searching
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult GetByFilter(string search=null)
        {
            var movies = _moviesService.Search(search);

            return Ok(movies);
        }
    }
}
