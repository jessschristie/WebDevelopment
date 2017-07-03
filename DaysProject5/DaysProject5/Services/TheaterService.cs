using DaysProject5.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace DaysProject5.Services
{
    public class TheaterService 
    {
        private TheaterDBContext db;
        //private ModelStateDictionary modelState;

        public TheaterService()
        {
            db = new TheaterDBContext();
        }

        public TheaterService(TheaterDBContext dbc)
        {
            db = dbc;
        }

        public IEnumerable<Movie> Read()
        {
            return GetData();
        }

        public List<Movie> CreateData(Movie obj)
        {
            db.Theater.Add(obj);
            db.SaveChanges();
            return db.Theater.ToList();
        }

        public Movie DeleteData(int? id)
        {
            Movie theater = db.Theater.Find(id);
            db.Theater.Remove(theater);
            db.SaveChanges();
            return theater;
        }

        public Movie EditData(Movie obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return obj;
        }

        public Movie FindData(int? id)
        {
            Movie theater = db.Theater.Find(id);
            return theater;
        }

        public List<Movie> GetData()
        {
            return db.Theater.ToList();
        }

        public void DestroyData(Movie obj)
        {
            var target = GetData().FirstOrDefault(p => p.ID == obj.ID);
            if (target != null)
            {
                db.Theater.Remove((Movie)target);
                db.SaveChanges();
            }
        }

        //void IService<Theater>.CreateData(Theater obj)
        //{
        //    throw new NotImplementedException();
        //}

        //void IService<Theater>.GetData()
        //{
        //    throw new NotImplementedException();
        //}

        //public void FindData(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //void IService<Theater>.EditData(Theater obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteData(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //Theater IService<Theater>.FindData(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}