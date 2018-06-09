using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.AppData;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly CmdDbContext _dbContext;

        public Repository(CmdDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        /*public virtual IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }*/

        public virtual IEnumerable<Movie> GetAll()
        {
            var movies = _dbContext.Set<Movie>().AsEnumerable();
            foreach (var movie in movies)
            {
                var movieId = movie.MovieId;
                var starrings = _dbContext.StarringDetails.Where(x => x.MovieId == movieId);
                var actors = new List<string>();
                foreach (var starring in starrings)
                {
                    var xx =_dbContext.Actors.Where(x => x.ActorId == starring.ActorId).ToList();
                    xx.ForEach(x => actors.Add(x.FirstName + " " + x.LastName));
                }
                var actorsString = string.Join(",", actors);
                movie.StarringActors = actorsString;
            }

            return movies;
        }

        public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                .Where(predicate)
                .AsEnumerable();
        }

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
    }
}
