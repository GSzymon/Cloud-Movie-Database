using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace Tests.Utils
{
    public static class ModelMocks
    {
        public static List<ActorMovie> GetActorMovieCollection()
        {
            var actors = new List<Actor>()
            {                                                                                                       //starring in movies:
                new Actor(), // for skip [0] cell                                                                   // [ids]
                new Actor() {ActorId = 1, FirstName = "Tim", LastName = "Robbins", Birthday = "1958-10-16"},        // 1
                new Actor() {ActorId = 2, FirstName = "Morgan", LastName = "Freeman", Birthday = "1937-06-01"},     // 1, 2, 4
                new Actor() {ActorId = 3, FirstName = "Omar", LastName = "Sy", Birthday = "1978-10-05"},            // 3
                new Actor() {ActorId = 4, FirstName = "Audrey", LastName = "Fleurot", Birthday = "1981-03-15"},     // 3
                new Actor() {ActorId = 5, FirstName = "Bruce", LastName = "Willis", Birthday = "1955-07-28"},       // -
                new Actor() {ActorId = 6, FirstName = "Johnny", LastName = "Depp", Birthday = "1980-12-01"},        // 4
                new Actor() {ActorId = 7, FirstName = "Jack", LastName = "Nicholson", Birthday = "1937-05-17"}      // -
            };

            var movies = new List<Movie>()
            {                                                                                                       //starring actors:
                new Movie(), // for skip [0] cell                                                                   // [ids]
                new Movie() {MovieId = 1, Title = "The Shawshank Redemption", Genre = "Drama", Year = 1994},        // 1, 2
                new Movie() {MovieId = 2, Title = "Se7en", Genre = "Crime", Year = 1995},                           // 2
                new Movie() {MovieId = 3, Title = "Intouchables", Genre = "Drama", Year = 2004},                    // 3, 4
                new Movie() {MovieId = 4, Title = "Transcendence", Genre = "Drama", Year = 2016},                   // 2, 6
            };

            var actorMovies = new List<ActorMovie>()
            {
                new ActorMovie() {Movie = movies[1], Actor = actors[1]},
                new ActorMovie() {Movie = movies[1], Actor = actors[2]},

                new ActorMovie() {Movie = movies[2], Actor = actors[2]},

                new ActorMovie() {Movie = movies[3], Actor = actors[3]},
                new ActorMovie() {Movie = movies[3], Actor = actors[4]},

                new ActorMovie() {Movie = movies[4], Actor = actors[2]},
                new ActorMovie() {Movie = movies[4], Actor = actors[6]}
            };

            return actorMovies;
        }
    }
}
