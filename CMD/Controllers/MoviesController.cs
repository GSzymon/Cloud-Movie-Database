using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.Validators;
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
            if(MovieValidator.IsValid(movieVm))
            {
                _moviesHandler.Add(movieVm);
            }
            else
            {
                Request.HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpPut("{movieId}")]
        public void UpdateMovie(int movieId, [FromBody]MovieViewModel movieVm)
        {
            if (MovieValidator.IsValid(movieVm))
            {
                _moviesHandler.Update(movieId, movieVm);
            }
            else
            {
                Request.HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpDelete("{movieId}")]
        public void DeleteMovie(int movieId)
        {
            _moviesHandler.Remove(movieId);
        }
    }
}
