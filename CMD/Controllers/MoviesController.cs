using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MoviesHandler _moviesHandler;

        public MoviesController(MoviesHandler moviesHandler)
        {
            _moviesHandler = moviesHandler;
        }

        [HttpGet]
        public JsonResult ListAllMovies()
        {
            return Json(_moviesHandler.GetAll());
        }
        
        [HttpGet("year/{year}")]
        public JsonResult ListMoviesByYear(int year)
        {
            return Json(_moviesHandler.GetByYear(year));
        }
        
        [HttpGet("actor/{id}")]
        public JsonResult ListMoviesWithGivenActor(int id)
        {
            return Json(_moviesHandler.ListMoviesWithGivenActor(id));
        }

        [HttpPost]
        public dynamic AddMovie([FromBody]Movie movie)
        {
            return _moviesHandler.Add(movie);
        }

        [HttpPut("{id}")]
        public dynamic UpdateMovie(int id, [FromBody]Movie movie)
        {
            return _moviesHandler.UpdateMovie(id, movie);
        }

        [HttpDelete("{id}")]
        public dynamic DeleteMovie(int id)
        {
            return _moviesHandler.DeleteMovie(id);
        }
    }
}
