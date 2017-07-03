using DaysProject5.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DaysProject5.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieDBContext db;

        public MovieRepository()
        {
            db = new MovieDBContext();
        }

        public MovieRepository(MovieDBContext dbc)
        {
            db = dbc;
        }

        public List<Movie> CreateData(Movie obj)
        {
            db.Movies.Add(obj);
            db.SaveChanges();
            return db.Movies.ToList();
        }

        public Movie DeleteData(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return movie;
        }

        public void DestroyData(Movie obj)
        {
            var target = GetData().FirstOrDefault(p => p.ID == obj.ID);
            if (target != null)
            {
                db.Movies.Remove(target);
                db.SaveChanges();
            }
        }

        public Movie EditData(Movie obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return obj;
        }

        public Movie FindData(int id)
        {
            Movie movie = db.Movies.Find(id);
            return movie;
        }

        public List<Movie> GetData()
        {
            return db.Movies.ToList();
        }

    }
}