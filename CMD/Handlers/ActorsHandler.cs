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
        private readonly IActorMovieRepository _repository;

        public IEnumerable<string> ListActorsStarringInMovie(int id)
        {
            throw new NotImplementedException();
        }

        public object LinkActorToExistingMovie(int id, Actor actor)
        {
            throw new NotImplementedException();
        }


        public ActorsHandler(IActorMovieRepository repository)
        {
            _repository = repository;
        }
    }
}
