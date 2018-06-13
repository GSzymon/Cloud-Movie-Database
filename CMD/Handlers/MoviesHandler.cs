using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Utills.Methods;
using WebAPI.ViewModels;

namespace WebAPI.Handlers
{
    public class MoviesHandler
    {
        private readonly IActorMovieRepository _repository;

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

            movie.Update(movieVm);

            foreach (var actorId in actorsIds)
            {
                var actor = _repository.SearchForActors(x => x.ActorId == actorId).First();
                actors.Add(actor);
            }

            actors.ForEach(x => _repository.Add(new ActorMovie() { Movie = movie, Actor = x }));
        }

        public void Update(int id, MovieViewModel movieVm)
        {
            var newActorsIds = movieVm.StarringActorsIds;
            var movie = _repository.SearchForMovies(x => x.MovieId == id).First();
            movie.Update(movieVm);

            var currentActorMovies = _repository.SearchForMovies(x => x.MovieId == id).First().ActorsMovies.AsEnumerable();
            var newActorMovies = newActorsIds.Select(x => new ActorMovie {ActorId = x, MovieId = id});

            _repository.Update(currentActorMovies, newActorMovies);
        }

        public void Remove(int id)
        {
            var movie = _repository.SearchForMovies(x => x.MovieId == id).First();
            _repository.RemoveMovie(movie);
        }

        public MoviesHandler(IActorMovieRepository repository)
        {
            _repository = repository;
        }
    }
}
