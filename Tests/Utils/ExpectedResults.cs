using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Utils
{
    public static class ExpectedResults
    {
        public static JsonResult ContentForTestListAllMovies()
        {
            return new JsonResult("test");
        }
    }
}
