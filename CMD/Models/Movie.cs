using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WebAPI.Models.Other;
using WebAPI.Repositories;
using WebAPI.ViewModels;

namespace WebAPI.Models
{
    public class Movie
    {
        private MovieViewModel movieVm;

        public Movie()
        {
            StarringDetails = new HashSet<ActorMovie>();
        }

        public Movie(MovieViewModel movieVm)
        {
            Title = movieVm.Title;
            Year = movieVm.Year;
            Genre = movieVm.Genre;
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string StarringActors { get; set; }

        [JsonIgnore]
        public ICollection<ActorMovie> StarringDetails { get; set; }

        public void AppendStarringActors(List<Person> actors)
        {
            var actorsToAppend = string.Join(", ", actors);
            StarringActors += actorsToAppend;
        }
    }
}
