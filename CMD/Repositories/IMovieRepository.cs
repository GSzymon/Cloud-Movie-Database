using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        IEnumerable<Movie> Get(Func<Movie, bool> predicate);
    }
}
