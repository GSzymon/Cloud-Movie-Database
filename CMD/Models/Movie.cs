using System.Collections.Generic;
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
        public Movie()
        {
            ActorsMovies = new HashSet<ActorMovie>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string StarringActors { get; set; }

        [JsonIgnore]
        public ICollection<ActorMovie> ActorsMovies { get; set; }

        public void Edit(string title, int year, string genre, string starringActors)
        {
            Title = title;
            Year = year;
            Genre = genre;
            StarringActors = starringActors;
        }
    }
}
