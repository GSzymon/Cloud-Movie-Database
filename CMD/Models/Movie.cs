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


        public static Movie Create(MovieViewModel movieVm)
        {
            return new Movie
            {
                Title = movieVm.Title,
                Year = movieVm.Year,
                Genre = movieVm.Genre
            };
        }
        public void AppendStarringActors(IEnumerable<Name> names)
        {
            var actorNames = names.Select(x => x.FirstName + " " + x.LastName);
            var actorsToAppend = string.Join(", ", actorNames);

            if (string.IsNullOrEmpty(StarringActors))
            {
                StarringActors = actorsToAppend;
            }
            else
            {
                StarringActors += ", " + actorsToAppend;
            }
        }
    }
}
