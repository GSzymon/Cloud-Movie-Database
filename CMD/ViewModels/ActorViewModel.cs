using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class ActorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public List<int> FilmographyIds { get; set; }

        public bool Equals(Actor actor)
        {
            if (FirstName.Equals(actor.FirstName) && 
                (LastName.Equals(actor.LastName) && 
                (Birthday == actor.Birthday)))
            {
                var filmographyIds = actor.ActorsMovies.Select(x => x.MovieId).ToList();
                bool equal = filmographyIds.OrderBy(i => i).SequenceEqual(FilmographyIds.OrderBy(i => i));
                if (equal)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
