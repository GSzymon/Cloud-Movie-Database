using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MoviesHandler _moviesHandler;
        
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
        
        [HttpGet("actor")]
        public JsonResult ListMoviesWithGivenActor([FromBody]string actorName)
        {
            return Json(_moviesHandler.ListMoviesWithGivenActor(actorName));
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

        public MoviesController(MoviesHandler moviesHandler)
        {
            _moviesHandler = moviesHandler;
        }
    }
}
