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
        private readonly IMovieRepository _movieRepository;

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
            var movie = new Movie();
            var actors = new List<Actor>();

            foreach (var actorId in actorsIds)
            {
                var actor = _actorRepository.SearchFor(x => x.ActorId == actorId).First();
                actors.Add(actor);
            }

            MovieHelpers.UpdateMovie(movie, movieVm, actors);
            ActorHelpers.AppendFilmography(actors, movie);

            actors.ForEach(x => _repository.Add(new ActorMovie() { Movie = movie, Actor = x }));
        }

        public void Update(int id, MovieViewModel movieVm)
        {
            var newActorsIds = movieVm.StarringActorsIds;
            var newActors = new List<Actor>();
            
            foreach (var actorId in newActorsIds)
            {
                var actor = _actorRepository.SearchFor(x => x.ActorId == actorId).First();
                newActors.Add(actor);
            }

            var movie = _movieRepository.SearchFor(x => x.MovieId == id).First();

            var currentActorMovies = _movieRepository.SearchFor(x => x.MovieId == id).First().ActorsMovies.AsEnumerable();

            var currentActorsIds = currentActorMovies.Select(x => x.Actor);
            var currentActors = _actorRepository.SearchFor(x => currentActorsIds.Contains(x)).ToList();

            ActorHelpers.UpdateActorsStarringInConcreteMovie(currentActors, newActors, movieVm.Title);
            MovieHelpers.UpdateMovie(movie, movieVm, currentActors);

            var newActorMovies = newActorsIds.Select(x => new ActorMovie {ActorId = x, MovieId = id});

            _repository.Update(currentActorMovies, newActorMovies);

        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MoviesHandler(IActorMovieRepository repository, IActorRepository actorRepository, IMovieRepository movieRepository)
        {
            _repository = repository;
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
        }
    }
}
