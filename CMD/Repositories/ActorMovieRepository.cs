using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.AppData;
using WebAPI.Models;
using WebAPI.Utills.Methods;

namespace WebAPI.Repositories
{
    public class ActorMovieRepository : IActorMovieRepository
    {
        private readonly CmdDbContext _context;

        public ActorMovieRepository(CmdDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ActorMovie> GetAll()
        {
            return _context.ActorsMovies.Include(x => x.Movie).Include(y => y.Actor);
        }

        public IEnumerable<ActorMovie> SearchFor(Func<ActorMovie, bool> predicate)
        {
            return _context.ActorsMovies.Include(x => x.Movie).Include(y => y.Actor).Where(predicate);
        }

        public IEnumerable<Movie> SearchForMovies(Func<Movie, bool> predicate)
        {
            var movies = _context.Movies.Include(x => x.ActorsMovies).Where(predicate);
            return movies;
        }

        public IEnumerable<Actor> SearchForActors(Func<Actor, bool> predicate)
        {
            var actors = _context.Actors.Include(x => x.ActorsMovies).Where(predicate);
            return actors;
        }

        public void Add(ActorMovie actorMovie)
        {
            _context.Add(actorMovie);
            _context.SaveChanges();
        }

        public void AddActor(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Update(IEnumerable<ActorMovie> oldActorMovies, IEnumerable<ActorMovie> newActorMovies)
        {
            _context.TryUpdateManyToMany(oldActorMovies, newActorMovies, x => x.ActorId);
            _context.SaveChanges();
        }

        public void RemoveMovie(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
        }
    }
}
