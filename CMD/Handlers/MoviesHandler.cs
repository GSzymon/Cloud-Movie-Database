using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.ViewModels;

namespace WebAPI.Handlers
{
    public class MoviesHandler
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;

        public IEnumerable<Movie> GetAll()
        {
            var content = _movieRepository.Get();
            return content.ToList();
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            var content = _movieRepository.SearchFor(item => item.Year == year);
            return content.ToList();
        }

        public IEnumerable<Movie> ListMoviesWithGivenActor(int actorId)
        {
            var starringDetails = _actorRepository.Get(actorId).StarringDetails.AsEnumerable().ToList();
            var movies = new List<Movie>();

            foreach (var item in starringDetails)
            {
                movies.Add(_movieRepository.Get(item.MovieId));
            }

            return movies;
        }

        public void Add(MovieViewModel movieVm)
        {
            var movie = new Movie(movieVm);
            foreach (var actorId in movieVm.StarringActorsIds)
            {
                var actor = _actorRepository.Get(actorId);
                actor.AppendFilmography(movieVm.Title);
                //movie.StarringDetails.Add(new StarringDetails(actorId, movieId));
            }
            
            _movieRepository.Insert(movie);
        }

        public object Update(int id, Movie movie)
        {
            throw new NotImplementedException();
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MoviesHandler(IMovieRepository movieRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
        }
    }
}
