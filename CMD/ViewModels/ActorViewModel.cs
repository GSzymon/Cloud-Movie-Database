using System.Collections.Generic;

namespace WebAPI.ViewModels
{
    public class ActorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public List<int> FilmographyIds { get; set; }
    }
}
