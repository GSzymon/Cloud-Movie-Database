using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Movies
    {
        public Movies()
        {
            StarringDetails = new HashSet<StarringDetails>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string StarringActors { get; set; }

        public ICollection<StarringDetails> StarringDetails { get; set; }
    }
}
