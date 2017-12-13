using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Interfaces;
using MoviesAPI.DB.DbModels;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        /// <summary>
        /// Add actor to movie
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]ActorRequest actorRequest)
        {
            if (!_actorService.AddActorsToMovie(AutoMapper.Mapper.Map<Actor>(actorRequest)))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}