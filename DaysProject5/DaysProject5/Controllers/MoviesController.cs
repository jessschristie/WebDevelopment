using System.Web.Mvc;
using DaysProject5.Models;
using DaysProject5.Services;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Collections.Generic;
using DaysProject5.ViewModel;
using System;
using System.Linq;

namespace DaysProject5.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieService<MovieViewModel> MovieServ = new MovieService();

        // GET: Movies
        public ActionResult Index()
        {
            ViewBag.Title = "Movies";
            return View(MovieServ.GetData());
        }

        public ActionResult LaunchWindow()
        {
            return PartialView("LaunchWindowCreate");
        }

        public ActionResult Custom_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(MovieServ.Read().ToDataSourceResult(request));
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            DataSourceResult result = MovieServ.Read().ToDataSourceResult(request, Mov => new Movie
            {
                ID = Mov.ID,
                Title = Mov.Title,
                WeekendRevenue = Mov.WeekendRevenue,
                GrossRevenue = Mov.GrossRevenue,
                Release = Mov.Release,
                Recommended = Mov.Recommended
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Update([DataSourceRequest] DataSourceRequest request, MovieViewModel obj)
        {
            if (ModelState.IsValid)
            {
                MovieServ.EditData(obj);
            }
            return Json(new[] { obj }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Destroy([DataSourceRequest] DataSourceRequest request, MovieViewModel obj)
        {
            if (obj != null)
            {
                MovieServ.DestroyData(obj);
            }

            return Json(new[] { obj }.ToDataSourceResult(request, ModelState));
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            MovieViewModel movie = MovieServ.FindData(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        //public bool CheckMovie(MovieViewModel model)
        //{
        //    return MovieServ.GetData().Any(x => x.Title == model.Title);
        //}

        // POST: Movies/Create
        [HttpPost]
        public ActionResult CreateMovie(MovieViewModel model)
        {
            
            model.ValidationErrors = new List<string>();

            if (ModelState.IsValid)
            {
                try
                {
                    MovieServ.CreateData(model);
                    return Json(new { model = model });
                }
                catch (Exception ex)
                {
                    model.ValidationErrors.Add(ex.Message);
                }
            }
            else
            {
                var errors = ModelState.Values.Where(x => (x.Errors != null) && (x.Errors.Count > 0)).SelectMany(x => x.Errors).Where(x => !string.IsNullOrEmpty(x.ErrorMessage) || (x.Exception != null));
                model.ValidationErrors.AddRange(errors.Select(x => x.ErrorMessage != "" ? x.ErrorMessage : x.Exception.Message));
                return Json(new { model = model });
            }
            //if (ModelState.IsValid)
            //{
            //    MovieServ.CreateData(movie);
            //    return RedirectToAction("Index");
            //}

            return View(model);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            MovieViewModel movie = MovieServ.FindData(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult EditMovie(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                MovieServ.EditData(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            MovieViewModel movie = MovieServ.FindData(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieServ.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}
