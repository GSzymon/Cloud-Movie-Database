using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.AppData;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly CmdDbContext _dbContext;

        public ActorRepository(CmdDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public Actor Get(int id)
        {
            var actor = _dbContext.Actors.Include(x => x.StarringDetails).First(y => y.ActorId == id);
            return actor;
        }

        public IEnumerable<Actor> Get()
        {
            var actors = _dbContext.Actors.Include(x => x.StarringDetails);
            return actors;
        }

        public IEnumerable<Actor> SearchFor(Func<Actor, bool> predicate)
        {
            var actors = _dbContext.Actors.Include(x => x.StarringDetails).Where(predicate);
            return actors;
        }

        public void Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Insert(Actor actor)
        {
            throw new NotImplementedException();
        }

    }
}
