﻿using System.Collections.Generic;
using Newtonsoft.Json;
using WebAPI.Repositories;

namespace WebAPI.Models
{
    public class Movie
    {
        public Movie()
        {
            StarringDetails = new HashSet<StarringDetails>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string StarringActors { get; set; }

        [JsonIgnore]
        public ICollection<StarringDetails> StarringDetails { get; set; }
        //public ICollection<int> StarringActorsIds { get; set; }
    }
}
