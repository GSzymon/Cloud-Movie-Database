using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MoviesHandler _moviesHandler;

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            var x = _moviesHandler.Get();
            return Json(x);
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return null; //_moviesHandler.Get();
        }

        // POST api/values
        [HttpPost]
        public dynamic Post([FromBody]Movie movie)
        {
            return _moviesHandler.Add(movie);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public MoviesController(MoviesHandler moviesHandler)
        {
            _moviesHandler = moviesHandler;
        }
    }
}
