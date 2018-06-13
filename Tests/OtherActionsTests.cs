using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mocks;
using Tests.Utils;
using WebAPI.AppData;
using WebAPI.Controllers;
using WebAPI.Handlers;
using WebAPI.Models;
using WebAPI.Repositories;

namespace Tests
{
    [TestClass]
    public class OtherActionsTests
    {
        private static MoviesController _moviesController;
        private static ActorsController _actorsController;
        private static CmdDbContext _context;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<CmdDbContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;

            _context = new CmdDbContext(options);
            _context.Database.EnsureCreated();

            _moviesController = new MoviesController(new MoviesHandler(new ActorMovieRepository(_context)));
            _actorsController = new ActorsController(new ActorsHandler(new ActorMovieRepository(_context)));

            DbHelpers.SeedDatabase(_context);
        }

        [TestMethod]
        public void TestAddMovieWithStarringActors()
        {
            var newMovieVm = ViewModelMocks.MovieVmWithStarringActors;
            _moviesController.AddMovie(newMovieVm);

            var addedMovie = _context.Set<Movie>().AsEnumerable().Last();
            Assert.IsTrue(newMovieVm.Equals(addedMovie));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAddMovieWithEmptyTitle()
        {
            var newMovieVm = ViewModelMocks.MovieVmWithEmptyTitle;
            _moviesController.AddMovie(newMovieVm);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAddMovieVmWithWrongYear()
        {
            var newMovieVm = ViewModelMocks.MovieVmWithWrongYear;
            _moviesController.AddMovie(newMovieVm);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAddMovieVmWithoutStarringActors()
        {
            var newMovieVm = ViewModelMocks.MovieVmWithoutStarringActors;
            _moviesController.AddMovie(newMovieVm);
        }

        [TestMethod]
        public void TestUpdateMovieVmWithStarringActors()
        {
            var newMovieVm = ViewModelMocks.MovieVmWithStarringActors;
            _moviesController.UpdateMovie(3, newMovieVm);

            var addedActorMovie = _context.Set<Movie>().AsEnumerable().First(x => x.MovieId == 3);
            Assert.IsTrue(newMovieVm.Equals(addedActorMovie));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestUpdateMovieVmForMovieWithoutActors()
        {
            var newMovieVm = ViewModelMocks.MovieVmWithoutStarringActors;
            _moviesController.UpdateMovie(3, newMovieVm);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestUpdateMovieVmWithEmptyTitle()
        {
            var newMovieVm = ViewModelMocks.MovieVmWithEmptyTitle;
            _moviesController.UpdateMovie(3, newMovieVm);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestUpdateMovieVmWithWrongYear()
        {
            var newMovieVm = ViewModelMocks.MovieVmWithWrongYear;
            _moviesController.UpdateMovie(3, newMovieVm);
        }

        [TestMethod]
        public void TestDeleteMovie()
        {
            _moviesController.DeleteMovie(1);
            try
            {
                _context.Movies.Select(x => x).First(y => y.MovieId == 1);
                Assert.IsTrue(false);
            }
            catch (Exception exception)
            {
            }

            try
            {
                _context.ActorsMovies.Select(y => y).First(z => z.MovieId == 1);
                Assert.IsTrue(false);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestDeleteNotExistingMovie()
        {
            _moviesController.DeleteMovie(123);
        }

        [TestMethod]
        public void TestLinkActorToExistingMovie()
        {
            _actorsController.LinkActorToExistingMovie(1, 3);
            try
            {
                _context.ActorsMovies.First(x => x.ActorId == 1 && x.MovieId == 3);
                Assert.IsTrue(true);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestLinkNotExistingActorToExistingMovie()
        {
            _actorsController.LinkActorToExistingMovie(123, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestLinkActorToNotExistingMovie()
        {
            _actorsController.LinkActorToExistingMovie(3, 123);
        }

        [TestMethod]
        public void TestAddActorWithFilomgraphy()
        {
            var newActorVm = ViewModelMocks.ActorVmWithFilmography;
            _actorsController.AddActor(newActorVm);

            var addedActor = _context.Set<Actor>().AsEnumerable().Last();
            Assert.IsTrue(newActorVm.Equals(addedActor));
        }

        [TestMethod]
        public void TestAddActorWithoutFilomgraphy()
        {
            var newActorVm = ViewModelMocks.ActorVmWithoutFilmography;
            _actorsController.AddActor(newActorVm);

            var addedActor = _context.Set<Actor>().AsEnumerable().Last();
            Assert.IsTrue(newActorVm.Equals(addedActor));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAddActorVmWithoutFirstName()
        {
            var newActorVm = ViewModelMocks.ActorVmWithoutFirstName;
            _actorsController.AddActor(newActorVm);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAddActorVmWithoutLastName()
        {
            var newActorVm = ViewModelMocks.ActorVmWithoutLastName;
            _actorsController.AddActor(newActorVm);
        }
    }
}