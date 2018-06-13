using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public void Add(ActorMovie actorMovie)
        {
            _context.Add(actorMovie);
            _context.SaveChanges();
        }

        public void Update(IEnumerable<ActorMovie> oldActorMovies, IEnumerable<ActorMovie> newActorMovies)
        {
            _context.TryUpdateManyToMany(oldActorMovies, newActorMovies, x => x.ActorId);
            _context.SaveChanges();
        }

        public void Remove(ActorMovie actorMovie)
        {
            _context.ActorsMovies.Remove(actorMovie);
            _context.SaveChanges();
        }
    }
}
