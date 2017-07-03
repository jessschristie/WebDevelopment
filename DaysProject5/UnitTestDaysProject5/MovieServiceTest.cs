using Microsoft.VisualStudio.TestTools.UnitTesting;
using DaysProject5.Services;
using DaysProject5.Models;
using DaysProject5.Repository;
using System.Collections.Generic;
using Moq;
using System.Linq;
using DaysProject5.ViewModel;
using System;

namespace UnitTestDaysProject5
{
    [TestClass]
    public class MovieServiceTest : MovieService
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Duplicate title")]
        public void CreateMovie_CheckDuplicateTitle_ShouldThrowException()
        {
            var data = new List<Movie>
            {
                new Movie {Title = "Movie"}
            };
            MovieViewModel movieModel = new MovieViewModel { Title = "Movie" };

            var mockSet = new Mock<IRepository<Movie>>();
            mockSet.Setup(m => m.GetData()).Returns(() => data);

            MovieService movService = new MovieService(mockSet.Object);
            movService.CreateData(movieModel);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Duplicate title")]
        public void EditMovie_CheckDuplicateTitle_ShouldThrowException()
        {
            var data = new List<Movie>
            {
                new Movie {ID = 1, Title = "Movie"}
            };
            MovieViewModel movieModel = new MovieViewModel { ID = 2, Title = "Movie" };

            var mockSet = new Mock<IRepository<Movie>>();
            mockSet.Setup(m => m.GetData()).Returns(() => data);

            MovieService movService = new MovieService(mockSet.Object);
            movService.EditData(movieModel);

        }

    }
}

