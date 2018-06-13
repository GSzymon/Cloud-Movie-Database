using Newtonsoft.Json;
using System.Collections.Generic;
using WebAPI.ViewModels;

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

        [JsonIgnore]
        public ICollection<ActorMovie> ActorsMovies { get; set; }

        public void Update(ActorViewModel actorVm)
        {
            FirstName = actorVm.FirstName;
            LastName = actorVm.LastName;
            Birthday = actorVm.Birthday;
        }
    }
}
