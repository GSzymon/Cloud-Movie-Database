using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IActorRepository
    {
        Actor Get(int actorId);
        IEnumerable<Actor> Get();
        IEnumerable<Actor> SearchFor(Func<Actor, bool> predicate);
        void Update(int id, Actor actor);
        void Insert(Actor actor);
    }
}
