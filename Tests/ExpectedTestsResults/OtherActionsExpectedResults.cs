﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.Models;

namespace Tests.ExpectedTestsResults
{
    public static class OtherActionsExpectedResults
    {
        // Movies controller:

       /* public static Movie TestAddMovieWithStarringActors()
        {
            
        }*/
        public static JsonResult TestAddMovieWithStarringActors()
        {
            var content = "[{\"MovieId\":5,\"Title\":\"A Perfect Day\",\"Year\":2015,\"Genre\":\"Drama\",\"ListStarringActors\":[{\"ActorId\":1,\"FirstName\":\"Tim\",\"LastName\":\"Robbins\",\"Birthday\":\"1958-10-16\"}]}]";
            var result = JsonConvert.DeserializeObject<List<ActorMovie>>(content);
            return new JsonResult(result);
        }
    }
}
