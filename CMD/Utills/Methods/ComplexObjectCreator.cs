﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Utills.Methods
{
    public static class ComplexObjectCreator
    {
        public static IEnumerable<ComplexMovie> GetComplexMovies(IEnumerable<ActorMovie> actorMovies)
        {
            var complexMovies = new List<ComplexMovie>();
            var movies = actorMovies.Select(x => x.Movie).Distinct();

            foreach (var movie in movies)
            {
                var starringActors = actorMovies.Where(x => x.MovieId == movie.MovieId).Select(x => x.Actor);
                var complexMovie = ComplexMovie.Create(movie, starringActors);
                complexMovies.Add(complexMovie);
            }

            return complexMovies;
        }
        /*
        public static ComplexMovie GetComplexMovie(IEnumerable<ActorMovie> actorMovies)
        {
            var movie = actorMovies.Select(x => x.Movie).First();
            var starringActors = actorMovies.Where(x => x.MovieId == movie.MovieId).Select(x => x.Actor);
            return ComplexMovie.Create(movie, starringActors);
        }
        */
    }
}