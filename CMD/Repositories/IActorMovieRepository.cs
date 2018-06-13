﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IActorMovieRepository
    {
        IEnumerable<ActorMovie> GetAll();
        IEnumerable<ActorMovie> SearchFor(Func<ActorMovie, bool> predicate);
        void Add(ActorMovie actorMovie);
        void Update(IEnumerable<ActorMovie> oldActorMovies, IEnumerable<ActorMovie> newActorMovies);
        void Remove(ActorMovie actor);
    }
}
