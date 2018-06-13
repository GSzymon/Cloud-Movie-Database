using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels;

namespace Tests.Utils
{
    public static class ViewModelMocks
    {
        public static MovieViewModel MovieVmWithStarringActors = new MovieViewModel()
        {
            Title = "A Perfect Day",
            Genre = "Drama",
            Year = 2015,
            StarringActorsIds = new List<int>() { 1 }
        };

        public static MovieViewModel MovieVmWithoutStarringActors = new MovieViewModel()
        {
            Title = "Inception",
            Genre = "Sci-Fi",
            Year = 2010,
            StarringActorsIds = new List<int>()
        };

        public static MovieViewModel MovieVmWithWrongYear = new MovieViewModel()
        {
            Title = "Shutter Island",
            Genre = "Sci-Fi",
            Year = 123,
            StarringActorsIds = new List<int>()
        };

        public static MovieViewModel MovieVmWithEmptyTitle = new MovieViewModel()
        {
            Title = "",
            Genre = "Sci-Fi",
            Year = 123,
            StarringActorsIds = new List<int>()
        };



        public static ActorViewModel ActorVmWithFilmography = new ActorViewModel()
        {
            FirstName = "Edward",
            LastName = "Norton",
            Birthday = "1969-07-16",
            FilmographyIds = new List<int>() { 2, 3, 4}
        };

        public static ActorViewModel ActorVmWithoutFilmography = new ActorViewModel()
        {
            FirstName = "Edward",
            LastName = "Furlong",
            Birthday = "1969-07-16",
            FilmographyIds = new List<int>()
        };

        public static ActorViewModel ActorVmWithoutLastName = new ActorViewModel()
        {
            FirstName = "Al",
            LastName = "",
            Birthday = "1940-05-11",
            FilmographyIds = new List<int>() { 1, 3}
        };

        public static ActorViewModel ActorVmWithoutFirstName = new ActorViewModel()
        {
            FirstName = "",
            LastName = "Pacino",
            Birthday = "1940-05-11",
            FilmographyIds = new List<int>() { 1 }
        };
    }
}
