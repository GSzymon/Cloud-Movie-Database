using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Utills.Methods;
using WebAPI.ViewModels;

namespace WebAPI.Handlers
{
    public class ActorsHandler
    {
        private readonly IActorMovieRepository _repository;

        public IEnumerable<ComplexActor> ListActorsStarringInMovie(int movieId)
        {
            var actorMovies = _repository.SearchFor(x => x.MovieId == movieId);
            var actors = ComplexObjectCreator.GetComplexActors(actorMovies);
            return actors;
        }

        public void Add(ActorViewModel actorVm)
        {
            var moviesIds = actorVm.FilmographyIds;
            var actor = new Actor();
            var movies = new List<Movie>();

            actor.Update(actorVm);

            foreach (var movieId in moviesIds)
            {
                var movie = _repository.SearchForMovies(x => x.MovieId== movieId).First();
                movies.Add(movie);
            }

            if (movies.Any())
            {
                movies.ForEach(x => _repository.Add(new ActorMovie() {Movie = x, Actor = actor}));
            }
            else
            {
                _repository.AddActor(actor);
            }
        }

        public void LinkActorToExistingMovie(int actorId, int movieId)
        {
            var currentActorMovies = _repository.SearchForMovies(x => x.MovieId == movieId).First().ActorsMovies.AsEnumerable();
            var currentActors = currentActorMovies.Select(x => x.Actor);
            var currentActorsIds = currentActors.Select(x => x.ActorId).ToList();

            var newActorsIds = currentActorsIds;
            newActorsIds.Add(actorId);
            
            var newActorMovies = newActorsIds.Select(x => new ActorMovie { ActorId = x, MovieId = movieId });

            _repository.Update(currentActorMovies, newActorMovies);
        }


        public ActorsHandler(IActorMovieRepository repository)
        {
            _repository = repository;
        }

        
    }
}
