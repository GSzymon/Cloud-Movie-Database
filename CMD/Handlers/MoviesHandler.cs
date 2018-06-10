using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;

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

        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public object UpdateMovie(int id, Movie movie)
        {
            throw new NotImplementedException();
        }

        public object DeleteMovie(int id)
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
