using System;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Handlers;
using WebAPI.Validators;
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
        public void AddActor([FromBody]ActorViewModel actorVm)
        {
            if (ActorValidator.IsValid(actorVm))
            {
                _actorsHandler.Add(actorVm);
            }
            else
            {
                Request.HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpPut("{actorId}/movie/{movieId}")]
        public void LinkActorToExistingMovie(int actorId, int movieId)
        {
            try
            {
                _actorsHandler.LinkActorToExistingMovie(actorId, movieId);
            }
            catch (Exception exception)
            {
                Request.HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
