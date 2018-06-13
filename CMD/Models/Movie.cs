﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using WebAPI.Models.Other;
using WebAPI.Repositories;
using WebAPI.ViewModels;

namespace WebAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        [JsonIgnore]
        public ICollection<ActorMovie> ActorsMovies { get; set; }

        public Movie()
        {
            ActorsMovies = new HashSet<ActorMovie>();
        }

        public void Update(MovieViewModel movieVm)
        {
            Title = movieVm.Title;
            Year = movieVm.Year;
            Genre = movieVm.Genre;
        }
    }
}
