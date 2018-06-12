using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.Other;
using WebAPI.Repositories;
using WebAPI.Utills.Methods;
using WebAPI.ViewModels;

namespace WebAPI.Handlers
{
    public class MoviesHandler
    {
        private readonly IActorMovieRepository _repository;
        private readonly IActorRepository _actorRepository;

        public IEnumerable<ComplexMovie> GetAll()
        {
            var actorMovies = _repository.GetAll();
            var content = ComplexObjectCreator.GetComplexMovies(actorMovies);
            return content;
        }

        public IEnumerable<ComplexMovie> GetByYear(int year)
        {
            var actorMovies = _repository.SearchFor(x => x.Movie.Year == year);
            var content = ComplexObjectCreator.GetComplexMovies(actorMovies);
            return content;
        }

        public IEnumerable<ComplexMovie> ListMoviesWithGivenActor(int actorId)
        {
            var actorMovies = _repository.SearchFor(x => x.ActorId == actorId);
            var content = ComplexObjectCreator.GetComplexMovies(actorMovies);
            return content;
        }

        public void Add(MovieViewModel movieVm)
        {
            var actorsIds = movieVm.StarringActorsIds;
            var movie = Movie.Create(movieVm);
            var actors = new List<Actor>();
            var names = new List<Name>();

            foreach (var actorId in actorsIds)
            {
                var actor = _repository.SearchFor(x => x.ActorId == actorId).Select(x => x.Actor).First();
                actors.Add(actor);
            }

            actors.ForEach(x => x.AppendFilmography(movieVm.Title));

            actors.ForEach(x => names.Add(new Name(x.FirstName, x.LastName)));
            movie.AppendStarringActors(names);

            actors.ForEach(x => _repository.Add(new ActorMovie() { Movie = movie, Actor = x }));
        }

        public void Update(int id, MovieViewModel movieVm)
        {
            var newActorsIds = movieVm.StarringActorsIds;
            var actors = new List<Actor>();
            var names = new List<Name>();
            //var staleActorsMovies = _repository.SearchFor(x => x.Movie.MovieId == id).First().Movie.ActorsMovies;

            foreach (var actorId in newActorsIds)
            {
                var actor = _actorRepository.SearchFor(x => x.ActorId == actorId).First();
               // var actor = _repository.SearchFor(x => x.Actor.ActorId == actorId);
                actors.Add(actor);
            }

            var movie = Movie.Create(movieVm);
            movie.MovieId = id;

            actors.ForEach(x => names.Add(new Name(x.FirstName, x.LastName)));
            movie.AppendStarringActors(names);
            //var names = new List<Name>();

            actors.ForEach(x => _repository.Update(new ActorMovie() { Movie = movie, Actor = x }));
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MoviesHandler(IActorMovieRepository repository, IActorRepository actorRepository)
        {
            _repository = repository;
            _actorRepository = actorRepository;
        }
    }
}
