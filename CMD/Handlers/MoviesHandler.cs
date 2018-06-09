using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Handlers
{
    public class MoviesHandler
    {
        private readonly IRepository<Movie> _repository;

        public List<Movie> Get()
        {
            var content = _repository.GetAll();
            return content.ToList();
        }

        public HttpStatusCode Add(Movie movie)
        {
            return HttpStatusCode.OK;
        }

        public MoviesHandler(IRepository<Movie> repository)
        {
            _repository = repository;
        }
    }
}
