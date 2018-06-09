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

        public IEnumerable<Movie> GetAll()
        {
            var content = _movieRepository.Get();
            return content.ToList();
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            var content = _movieRepository.Get(item => item.Year == year);
            return content.ToList();
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        public IEnumerable<Movie> ListMoviesWithGivenActor(string actorName)
        {
            var content = _movieRepository.Get(item => item.StarringActors.Contains(actorName));
            return content;
        }

        public HttpResponse Add(Movie movie)
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


        public MoviesHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
    }
}
