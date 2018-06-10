using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.Models;

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

        [HttpGet("id/{id}")]
        public JsonResult ListActorsStarringInMovie(int id)
        {
            return Json(_actorsHandler.ListActorsStarringInMovie(id));
        }

        [HttpPut("{id}")]
        public dynamic LinkActorToExistingMovie(int id, [FromBody]Actor actor)
        {
            return _actorsHandler.LinkActorToExistingMovie(id, actor);
        }
    }
}
