using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Utills.Methods
{
    public static class ActorHelpers
    {
        public static IEnumerable<string> GetNamesCollection(IEnumerable<Actor> actors)
        {
            return actors.Select(actor => actor.FirstName + " " + actor.LastName);
        }

        public static List<string> GetActorFilmography(string filmography)
        {
            if (string.IsNullOrEmpty(filmography))
            {
                return new List<string>();
            }
            return filmography.Split(", ").ToList();
        }

        public static string GetActorFilmographyAsString(IEnumerable<string> filmography)
        {
            return string.Join(", ", filmography);
        }

        public static string GetNamesCollectionAsString(IEnumerable<Actor> actors)
        {
            var names = actors.Select(actor => actor.FirstName + " " + actor.LastName);
            return string.Join(", ", names);
        }

        public static void UpdateActorsStarringInConcreteMovie(List<Actor> currentActors, List<Actor> newActors, string title)
        {
            foreach (var actor in currentActors)
            {
                var currentActorFilmography = GetActorFilmography(actor.Filmography);
                currentActorFilmography.RemoveAll(x => x == title);
                actor.Filmography = GetActorFilmographyAsString(currentActorFilmography);
            }

            foreach (var actor in newActors)
            {
                var currentActorFilmography = GetActorFilmography(actor.Filmography);
                currentActorFilmography.Add(title);
                actor.Filmography = GetActorFilmographyAsString(currentActorFilmography);
            }
        }

        public static void AppendFilmography(List<Actor> actors, Movie movie)
        {
            foreach (var actor in actors)
            {
                if (string.IsNullOrEmpty(actor.Filmography))
                {
                    actor.Filmography = movie.Title;
                }
                else
                {
                    actor.Filmography += ", " + movie.Title;
                }
            }
        }
    }
}
