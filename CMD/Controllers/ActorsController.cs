using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private readonly ActorsHandler _actorsHandler;

        public ActorsController(ActorsHandler actorsHandler)
        {
            _actorsHandler = actorsHandler;
        }

        [HttpGet("{movieId}")]
        public JsonResult ListActorsStarringInMovie(int movieId)
        {
            return Json(_actorsHandler.ListActorsStarringInMovie(movieId));
        }

        [HttpPost]
        public void AddMovie([FromBody]ActorViewModel movieVm)
        {
            _actorsHandler.Add(movieVm);
        }

        [HttpPut("{actorId}/movie/{movieId}")]
        public void LinkActorToExistingMovie(int actorId, int movieId)
        {
            _actorsHandler.LinkActorToExistingMovie(actorId, movieId);
        }
    }
}
