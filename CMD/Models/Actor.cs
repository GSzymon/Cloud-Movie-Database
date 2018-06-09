using System.Collections.Generic;
using WebAPI.Repositories;

namespace WebAPI.Models
{
    public class Actor : EntityBase
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

        public ICollection<StarringDetails> StarringDetails { get; set; }
    }
}
