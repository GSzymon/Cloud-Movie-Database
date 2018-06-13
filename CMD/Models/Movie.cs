using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebAPI.ViewModels;

namespace WebAPI.Models
{
    public class Movie
    {
        private int _year;

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year
        {
            get => _year;
            set {
                if (value > DateTime.Today.Year) { _year = -1; }
                else { _year = value; }
            }
        }
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
