using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class StarringDetails
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
