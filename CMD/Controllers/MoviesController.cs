using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.ViewModels;

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
        
        [HttpGet("actor/{actorId}")]
        public JsonResult ListMoviesWithGivenActor(int actorId)
        {
            return Json(_moviesHandler.ListMoviesWithGivenActor(actorId));
        }

        [HttpPost]
        public void AddMovie([FromBody]MovieViewModel movieVm)
        {
            _moviesHandler.Add(movieVm);
        }

        [HttpPut("{movieId}")]
        public void UpdateMovie(int movieId, [FromBody]MovieViewModel movieVm)
        {
            _moviesHandler.Update(movieId, movieVm);
        }

        [HttpDelete("{movieId}")]
        public void DeleteMovie(int movieId)
        {
            _moviesHandler.Remove(movieId);
        }
    }
}
