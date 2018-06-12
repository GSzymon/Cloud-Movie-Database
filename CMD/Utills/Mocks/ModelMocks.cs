using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Utills.Mocks
{
    public static class ModelMocks
    {
        public static Movie GetMovie1()
        {
            var movie = new Movie();
            movie.Title = "test title 1";
            movie.Year = 1234;
            movie.Genre = "test genre 1";

            

            return movie;
        }

    }
}
