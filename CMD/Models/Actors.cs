using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Actors
    {
        public Actors()
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
