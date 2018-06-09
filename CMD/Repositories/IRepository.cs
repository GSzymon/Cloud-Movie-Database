using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        //IEnumerable<T> List();
        //IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<Movie> GetAll();
        //IEnumerable<Movie> GetAll();
    }

    public abstract class EntityBase
    { }
}
