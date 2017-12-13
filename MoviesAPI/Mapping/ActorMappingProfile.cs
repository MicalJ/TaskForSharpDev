using AutoMapper;
using MoviesAPI.DB.DbModels;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Mapping
{
    public class ActorMappingProfile : Profile
    {
        public ActorMappingProfile()
        {
            CreateMap<ActorRequest, Actor>();
            CreateMap<Actor, ActorResponse>();
        }
    }
}
