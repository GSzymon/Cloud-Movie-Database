using System.Collections.Generic;
using Newtonsoft.Json;
using WebAPI.Repositories;

namespace WebAPI.Models
{
    public class Actor
    {
        public Actor()
        {
            StarringDetails = new HashSet<StarringDetails>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Filmography { get; set; }

        [JsonIgnore]
        public ICollection<StarringDetails> StarringDetails { get; set; }
    }
}
