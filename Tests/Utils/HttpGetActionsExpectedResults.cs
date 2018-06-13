using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.ViewModels;

namespace Tests.Utils
{
    public static class HttpGetActionsExpectedResults
    {
        // MoviesController:
        public static JsonResult TestListAllMovies()
        {
            var content = "[{\"movieId\":1,\"title\":\"The Shawshank Redemption\",\"year\":1994,\"genre\":\"Drama\",\"listStarringActors\":[{\"actorId\":1,\"firstName\":\"Tim\",\"lastName\":\"Robbins\",\"birthday\":\"1958-10-16\"},{\"actorId\":2,\"firstName\":\"Morgan\",\"lastName\":\"Freeman\",\"birthday\":\"1937-06-01\"}]},{\"movieId\":2,\"title\":\"Se7en\",\"year\":1995,\"genre\":\"Crime\",\"listStarringActors\":[{\"actorId\":2,\"firstName\":\"Morgan\",\"lastName\":\"Freeman\",\"birthday\":\"1937-06-01\"}]},{\"movieId\":3,\"title\":\"Intouchables\",\"year\":2004,\"genre\":\"Drama\",\"listStarringActors\":[{\"actorId\":3,\"firstName\":\"Omar\",\"lastName\":\"Sy\",\"birthday\":\"1978-10-05\"},{\"actorId\":4,\"firstName\":\"Audrey\",\"lastName\":\"Fleurot\",\"birthday\":\"1981-03-15\"}]},{\"movieId\":4,\"title\":\"Transcendence\",\"year\":2016,\"genre\":\"Drama\",\"listStarringActors\":[{\"actorId\":2,\"firstName\":\"Morgan\",\"lastName\":\"Freeman\",\"birthday\":\"1937-06-01\"},{\"actorId\":6,\"firstName\":\"Johnny\",\"lastName\":\"Depp\",\"birthday\":\"1980-12-01\"}]}]";
            var result = JsonConvert.DeserializeObject<List<ComplexMovie>>(content);
            return new JsonResult(result);
        }

        public static JsonResult TestListMoviesByProperYear()
        {
            var content = "[{\"movieId\":1,\"title\":\"The Shawshank Redemption\",\"year\":1994,\"genre\":\"Drama\",\"listStarringActors\":[{\"actorId\":1,\"firstName\":\"Tim\",\"lastName\":\"Robbins\",\"birthday\":\"1958-10-16\"},{\"actorId\":2,\"firstName\":\"Morgan\",\"lastName\":\"Freeman\",\"birthday\":\"1937-06-01\"}]}]";
            var result = JsonConvert.DeserializeObject<List<ComplexMovie>>(content);
            return new JsonResult(result);
        }

        public static JsonResult TestListMoviesWithGivenProperActor()
        {
            var content = "[{\"movieId\":1,\"title\":\"The Shawshank Redemption\",\"year\":1994,\"genre\":\"Drama\",\"listStarringActors\":[{\"actorId\":2,\"firstName\":\"Morgan\",\"lastName\":\"Freeman\",\"birthday\":\"1937-06-01\"}]},{\"movieId\":2,\"title\":\"Se7en\",\"year\":1995,\"genre\":\"Crime\",\"listStarringActors\":[{\"actorId\":2,\"firstName\":\"Morgan\",\"lastName\":\"Freeman\",\"birthday\":\"1937-06-01\"}]},{\"movieId\":4,\"title\":\"Transcendence\",\"year\":2016,\"genre\":\"Drama\",\"listStarringActors\":[{\"actorId\":2,\"firstName\":\"Morgan\",\"lastName\":\"Freeman\",\"birthday\":\"1937-06-01\"}]}]";
            var result = JsonConvert.DeserializeObject<List<ComplexMovie>>(content);
            return new JsonResult(result);
        }


        // ActorsController:
        public static JsonResult TestListActorsStarringInMovie()
        {
            var content = "[{\"actorId\":2,\"firstName\":\"Morgan\",\"lastName\":\"Freeman\",\"birthday\":\"1937-06-01\",\"filmography\":[{\"movieId\":4,\"title\":\"Transcendence\",\"year\":2016,\"genre\":\"Drama\"}]},{\"actorId\":6,\"firstName\":\"Johnny\",\"lastName\":\"Depp\",\"birthday\":\"1980-12-01\",\"filmography\":[{\"movieId\":4,\"title\":\"Transcendence\",\"year\":2016,\"genre\":\"Drama\"}]}]";
            var result = JsonConvert.DeserializeObject<List<ComplexActor>>(content);
            return new JsonResult(result);
        }
    }
}
