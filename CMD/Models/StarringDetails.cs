using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class StarringDetails
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public Actors Actor { get; set; }
        public Movies Movie { get; set; }
    }
}
