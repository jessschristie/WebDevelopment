using DaysProject5.Models;
using DaysProject5.Repository;
using DaysProject5.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DaysProject5.Services
{
    public class MovieService : IMovieService<MovieViewModel>
    {
        private IRepository<Movie> MovieRepo;

        public MovieService()
        {
            MovieRepo = new MovieRepository();
        }

        public MovieService(IRepository<Movie> movieRepo)
        {
            MovieRepo = movieRepo;
        }

        public IEnumerable<MovieViewModel> Read()
        {
            return GetData();
        }

        public bool CheckMovie(MovieViewModel model)
        {
            return GetData().Any(x => x.Title == model.Title && x.ID != model.ID);
        }

        public void CreateData(MovieViewModel obj)
        {
            if (!CheckMovie(obj))
            {
                var movie = new Movie
                {
                    ID = obj.ID,
                    Title = obj.Title,
                    GrossRevenue = obj.GrossRevenue,
                    WeekendRevenue = obj.WeekendRevenue,
                    Release = obj.Release,
                    Recommended = obj.Recommended
                };
                MovieRepo.CreateData(movie);
            }
            else
            {
                throw new Exception("Duplicate title");
            }
            
        }

        public void DeleteData(int id)
        {
            MovieRepo.DeleteData(id);
        }

        public void EditData(MovieViewModel obj)
        {
            if (!CheckMovie(obj))
            {
                var movie = new Movie
                {
                    ID = obj.ID,
                    Title = obj.Title,
                    GrossRevenue = obj.GrossRevenue,
                    WeekendRevenue = obj.WeekendRevenue,
                    Release = obj.Release,
                    Recommended = obj.Recommended
                };
                MovieRepo.EditData(movie);
            }
            else
            {
                throw new Exception("Duplicate title");
            }

        }

        public MovieViewModel FindData(int id)
        {
            var movRepo = MovieRepo.FindData(id);

            var movie = new MovieViewModel
            {
                ID = movRepo.ID,
                Title = movRepo.Title,
                GrossRevenue = movRepo.GrossRevenue,
                WeekendRevenue = movRepo.WeekendRevenue,
                Release = movRepo.Release,
                Recommended = movRepo.Recommended
            };

            return movie;
        }

        public List<MovieViewModel> GetData()
        {
            List<Movie> movList = MovieRepo.GetData();
            var mov = movList.Select(x => new MovieViewModel
            {
                ID = x.ID,
                Title = x.Title,
                GrossRevenue = x.GrossRevenue,
                WeekendRevenue = x.WeekendRevenue,
                Release = x.Release,
                Recommended = x.Recommended

            });

            return mov.ToList();
        }

        public void DestroyData(MovieViewModel obj)
        {
            var movieVM = new MovieViewModel();
            var movie = new Movie
            {
                ID = obj.ID,
                Title = obj.Title,
                GrossRevenue = obj.GrossRevenue,
                WeekendRevenue = obj.WeekendRevenue,
                Release = obj.Release,
                Recommended = obj.Recommended
            };
            MovieRepo.DestroyData(movie);
        }
    }
}