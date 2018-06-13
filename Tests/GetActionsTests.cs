using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Tests.ExpectedTestsResults;
using Tests.Utils;
using WebAPI.AppData;
using WebAPI.Controllers;
using WebAPI.Handlers;
using WebAPI.Repositories;

namespace Tests
{
    [TestClass]
    public class GetActionsTests
    {
        private static MoviesController _moviesController;
        private static ActorsController _actorsController;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<CmdDbContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;

            var context = new CmdDbContext(options);
            context.Database.EnsureCreated();

            _moviesController = new MoviesController(new MoviesHandler(new ActorMovieRepository(context)));
            _actorsController = new ActorsController(new ActorsHandler(new ActorMovieRepository(context)));

            DbHelpers.SeedDatabase(context);
        }

        // MoviesController:
        [TestMethod]
        public void TestListAllMovies()
        {
            var movies = JsonConvert.SerializeObject(_moviesController.ListAllMovies().Value);
            var expectedMovies = JsonConvert.SerializeObject(HttpGetActionsExpectedResults.TestListAllMovies().Value);

            var result = movies.Equals(expectedMovies);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestListMoviesByProperYear()
        {
            var movies = JsonConvert.SerializeObject(_moviesController.ListMoviesByYear(1994).Value);
            var expectedMovies = JsonConvert.SerializeObject(HttpGetActionsExpectedResults.TestListMoviesByProperYear().Value);

            var result = movies.Equals(expectedMovies);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestListMoviesByWrongYear()
        {
            var movies = JsonConvert.SerializeObject(_moviesController.ListMoviesByYear(12).Value);
            var expectedMovies = "[]";

            var result = movies.Equals(expectedMovies);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestListMoviesWithGivenProperActor()
        {
            var movies = JsonConvert.SerializeObject(_moviesController.ListMoviesWithGivenActor(2).Value);
            var expectedMovies = JsonConvert.SerializeObject(HttpGetActionsExpectedResults.TestListMoviesWithGivenProperActor().Value);

            var result = movies.Equals(expectedMovies);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestListMoviesWithGivenWrongActor()
        {
            var movies = JsonConvert.SerializeObject(_moviesController.ListMoviesWithGivenActor(123).Value);
            var expectedMovies = "[]";

            var result = movies.Equals(expectedMovies);
            Assert.IsTrue(result);
        }

        // ActorsController:
        [TestMethod]
        public void TestListActorsStarringInMovie()
        {
            var actors = JsonConvert.SerializeObject(_actorsController.ListActorsStarringInMovie(4).Value);
            var expectedActors = JsonConvert.SerializeObject(HttpGetActionsExpectedResults.TestListActorsStarringInMovie().Value);

            var result = actors.Equals(expectedActors);
            Assert.IsTrue(result);
        }
    }
}
