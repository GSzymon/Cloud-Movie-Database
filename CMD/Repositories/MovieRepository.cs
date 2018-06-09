using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAPI.AppData;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CmdDbContext _dbContext;

        public MovieRepository(CmdDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> Get()
        {
            var movies = _dbContext.Set<Movie>().AsEnumerable();
            IncludeNestedData(movies);
            return movies;
        }

        //public virtual IEnumerable<Movie> Get(Expression<Func<Movie, bool>> predicate)
        public IEnumerable<Movie> Get(Func<Movie, bool> predicate)
        {
            //var movies = _dbContext.Set<Movie>().Where(predicate).AsEnumerable();
            var movies = _dbContext.Movies.Where(predicate); //Where(x => x.).AsEnumerable();
            IncludeNestedData(movies);
            return movies;
        }
        /*
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        */

        private void IncludeNestedData(IEnumerable<Movie> movies)
        {
            foreach (var movie in movies)
            {
                var starrings = _dbContext.StarringDetails.Where(x => x.MovieId == movie.MovieId);
                var starringActorsNames = new List<string>();
                foreach (var starring in starrings)
                {
                    var concreteActors = _dbContext.Actors.Where(x => x.ActorId == starring.ActorId).ToList();
                    concreteActors.ForEach(x => starringActorsNames.Add(x.FirstName + " " + x.LastName));
                }
                movie.StarringActors = string.Join(", ", starringActorsNames);
            }
        }
    }
}
