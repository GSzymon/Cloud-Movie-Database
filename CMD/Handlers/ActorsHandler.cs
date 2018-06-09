using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Handlers
{
    public class ActorsHandler
    {
        private readonly IActorRepository _actorRepository;

        public IEnumerable<string> ListActorsStarringInMovie(int id)
        {
            throw new NotImplementedException();
        }

        public object LinkActorToExistingMovie(int id, Actor actor)
        {
            throw new NotImplementedException();
        }


        public ActorsHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
    }
}
