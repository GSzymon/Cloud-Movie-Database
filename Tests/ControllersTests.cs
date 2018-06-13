using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.AppData;
using WebAPI.Controllers;
using WebAPI.Handlers;
using WebAPI.Repositories;
using WebAPI.ViewModels;

namespace Tests
{
    [TestClass]
    public class ControllersTests
    {
        [TestMethod]
        public void Add_writes_to_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<CmdDbContext>()
                    .UseSqlite(connection)
                    .Options;


                var context = new CmdDbContext(options);
                // Create the schema in the database

                context.Database.EnsureCreated();


                var moviesController = new MoviesController(new MoviesHandler(new ActorMovieRepository(context)));
                var actorsController = new ActorsController(new ActorsHandler(new ActorMovieRepository(context)));

                actorsController.AddActor(new ActorViewModel()
                {
                    FirstName = "testName",
                    LastName = "testLast",
                    Birthday = "2010-10-10",
                    FilmographyIds = new List<int>()
                });

                var actorsIds = new List<int>();
                actorsIds.Add(0);

                moviesController.AddMovie(new MovieViewModel()
                {
                    Title = "testMovie",
                    Genre = "testGenre",
                    Year = 2000,
                    StarringActorsIds = actorsIds
                });
                /*
                // Run the test against one instance of the context
                using (var context = new CmdDbContext(options)) 
                {
                    var service = new ActorsController(context);
                    service.Add("http://sample.com");
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new BloggingContext(options))
                {
                    Assert.AreEqual(1, context.Blogs.Count());
                    Assert.AreEqual("http://sample.com", context.Blogs.Single().Url);
                }
                */
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
