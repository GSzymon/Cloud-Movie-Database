using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Utils;
using WebAPI.AppData;
using WebAPI.Controllers;
using WebAPI.Handlers;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.ViewModels;

namespace Tests
{
    [TestClass]
    public class ControllersTests
    {
        private MoviesController _moviesController;
        private ActorsController _actorsController;

        [TestInitialize]
        public void Initialize()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<CmdDbContext>()
                .UseSqlite(connection)
                .Options;

            var context = new CmdDbContext(options);
            context.Database.EnsureCreated();

            _moviesController = new MoviesController(new MoviesHandler(new ActorMovieRepository(context)));
            _actorsController = new ActorsController(new ActorsHandler(new ActorMovieRepository(context)));

            DbHelpers.SeedDatabase(context);
        }

        [TestMethod]
        public void TestListAllMovies()
        {
            var movies = _moviesController.ListAllMovies();
            var expectedContent = new JsonResult(ModelMocks.GetActorMovieCollection());
            var isOk = movies.Equals(expectedContent);
            var xx = 5;
        }

        
    }
}
