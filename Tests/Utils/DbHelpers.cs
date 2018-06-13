using Tests.Mocks;
using WebAPI.AppData;

namespace Tests.Utils
{
    public static class DbHelpers
    {
        public static void SeedDatabase(CmdDbContext context)
        {
            var actorMovieCollection = ModelMocks.GetActorMovieCollection();
            var actorsWithEmptyFilmography = ModelMocks.GetActorsWithEmptyFilmography();

            context.AddRange(actorMovieCollection);
            context.AddRange(actorsWithEmptyFilmography);

            context.SaveChanges();
        }
    }
}
