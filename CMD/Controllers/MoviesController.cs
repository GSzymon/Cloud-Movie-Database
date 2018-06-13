using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.Models;
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
        
        [HttpGet("actor/{id}")]
        public JsonResult ListMoviesWithGivenActor(int id)
        {
            return Json(_moviesHandler.ListMoviesWithGivenActor(id));
        }

        [HttpPost]
        public void AddMovie([FromBody]MovieViewModel movieVm)
        {
            _moviesHandler.Add(movieVm);
        }

        [HttpPut("{id}")]
        public void UpdateMovie(int id, [FromBody]MovieViewModel movieVm)
        {
            _moviesHandler.Update(id, movieVm);
        }

        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            _moviesHandler.Remove(id);
        }
    }
}
