﻿using MoviesAPI.DB.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Models
{
    public class ActorResponse
    {
        public ICollection<Movie> Movie { get; set; }
    }
}
