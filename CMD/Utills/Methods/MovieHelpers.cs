using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Other;
using WebAPI.ViewModels;

namespace WebAPI.Utills.Methods
{
    public static class MovieHelpers
    {
        public static void UpdateMovie(Movie movie, MovieViewModel movieVm, List<Actor> currentActors)
        {
            var actorsNames = ActorHelpers.GetNamesCollectionAsString(currentActors);
            movie.Edit(movieVm.Title, movieVm.Year, movieVm.Genre, actorsNames);
        }

        public static void AppendStarringActor(Movie movie, Actor actor)
        {
            var actorName = actor.GetName();
            movie.StarringActors += ", " + actorName;
        }
    }
}
