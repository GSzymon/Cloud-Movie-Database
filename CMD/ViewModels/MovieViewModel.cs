using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public List<int> StarringActorsIds { get; set; }

        public bool Equals(Movie movie)
        {
            if (Title.Equals(movie.Title) &&
                (Year == movie.Year) &&
                (Genre == movie.Genre))
            {
                var actorsIds = movie.ActorsMovies.Select(x => x.ActorId).ToList();
                bool equal = actorsIds.OrderBy(i => i).SequenceEqual(StarringActorsIds.OrderBy(i => i));
                if (equal)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
