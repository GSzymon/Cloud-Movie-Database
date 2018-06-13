using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class ComplexActor
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public IEnumerable<Movie> Filmography { get; set; } = new List<Movie>();

        public static ComplexActor Create(Actor actor, IEnumerable<Movie> movies)
        {
            return new ComplexActor
            {
                ActorId = actor.ActorId,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Birthday = actor.Birthday,
                Filmography = movies
            };
        }
    }
}
