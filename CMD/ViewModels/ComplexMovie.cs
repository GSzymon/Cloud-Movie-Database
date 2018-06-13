using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class ComplexMovie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public IEnumerable<Actor> ListStarringActors { get; set; }

        public static ComplexMovie Create(Movie movie, IEnumerable<Actor> actors)
        {
            return new ComplexMovie
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Year = movie.Year,
                Genre = movie.Genre,
                ListStarringActors = actors
            };
        }
    }
}
