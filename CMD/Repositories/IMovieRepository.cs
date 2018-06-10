using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IMovieRepository
    {
        Movie Get(int movieId);
        IEnumerable<Movie> Get();
        IEnumerable<Movie> SearchFor(Func<Movie, bool> predicate);
        void Update(int id, Movie movie);
        void Insert(Movie movie);
    }
}
