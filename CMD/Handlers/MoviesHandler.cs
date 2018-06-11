using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.Other;
using WebAPI.Repositories;
using WebAPI.ViewModels;

namespace WebAPI.Handlers
{
    public class MoviesHandler
    {
        private readonly IActorMovieRepository _repository;

        public IEnumerable<Movie> GetAll()
        {
            var actorMovies = _repository.GetAll();
            return actorMovies.Select(x => x.Movie);
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            var actorMovies = _repository.SearchFor(x => x.Movie.Year == year);
            return actorMovies.Select(x => x.Movie);
        }

        public IEnumerable<Movie> ListMoviesWithGivenActor(int actorId)
        {
            var actorMovies = _repository.SearchFor(x => x.ActorId == actorId);
            return actorMovies.Select(x => x.Movie);
        }

        public void Add(MovieViewModel movieVm)
        {
            /*
            var movie = new Movie(movieVm);
            var actors = new List<Actor>();
            var actorsMovies = new List<ActorMovie>();
            var people = new List<Person>();

            movieVm.StarringActorsIds.ForEach(x => actors.Add(_actorRepository.Get(x)));
            actors.ForEach(x => x.AppendFilmography(movieVm.Title));
            actors.ForEach(x => people.Add(new Person(x.FirstName, x.LastName)));
            movie.AppendStarringActors(people);

            actorsMovies.ForEach(x=> _repository.Insert(movie)); // zmienic na jedno repository (ActorMovie)
            */   
        }

        public object Update(int id, Movie movie)
        {
            throw new NotImplementedException();
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MoviesHandler(IActorMovieRepository repository)
        {
            _repository = repository;
        }
    }
}
