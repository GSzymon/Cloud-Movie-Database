using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPI.AppData;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public readonly CmdDbContext _dbContext;

        public MovieRepository(CmdDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Movie Get(int id)
        {
            var movie = _dbContext.Movies.Include(x => x.ActorsMovies).First(y => y.MovieId == id);
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            var movies = _dbContext.Movies.Include(x => x.ActorsMovies);
            return movies;
        }

        public IEnumerable<Movie> SearchFor(Func<Movie, bool> predicate)
        {
            var movies = _dbContext.Movies.Include(x => x.ActorsMovies).Where(predicate); 
            return movies;
        }
        
        public void Update(int id, Movie movie)
        {

        }

        public void Insert(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Insert(ActorMovie actorMovie)
        {
            _dbContext.ActorsMovies.Add(actorMovie);
            _dbContext.SaveChanges();
        }
    }
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
