using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebAPI.ViewModels;

namespace WebAPI.Models
{
    public class Actor
    {
        private string _birthday;

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday
        {
            get => _birthday.Substring(0, 10);
            set => _birthday = value;
        }

        [JsonIgnore]
        public ICollection<ActorMovie> ActorsMovies { get; set; }

        public Actor()
        {
            ActorsMovies = new HashSet<ActorMovie>();
        }

        public void Update(ActorViewModel actorVm)
        {
            FirstName = actorVm.FirstName;
            LastName = actorVm.LastName;
            Birthday = actorVm.Birthday;
        }
    }
}
