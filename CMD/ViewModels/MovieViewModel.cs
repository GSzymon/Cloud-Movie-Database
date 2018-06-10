using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public List<int> StarringActorsIds { get; set; }
    }
}
