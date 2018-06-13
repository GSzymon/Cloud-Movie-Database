using System.Collections.Generic;
using Newtonsoft.Json;
using WebAPI.Repositories;

namespace WebAPI.Models
{
    public class Actor
    {
        public Actor()
        {
            ActorsMovies = new HashSet<ActorMovie>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Filmography { get; set; }

        [JsonIgnore]
        public ICollection<ActorMovie> ActorsMovies { get; set; }

        public string GetName()
        {
            return FirstName + " " + LastName;
        }
    }
}
