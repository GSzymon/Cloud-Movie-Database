using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.AppData;
using WebAPI.Models;

namespace Tests.Utils
{
    public static class DbHelpers
    {
        public static void SeedDatabase(CmdDbContext context)
        {
            var data = ModelMocks.GetActorMovieCollection();
            context.AddRange(data);
            context.SaveChanges();
        }
    }
}
