//using System.Net;
//using System.Web.Mvc;
//using DaysProject5.Models;
//using DaysProject5.Services;
//using Kendo.Mvc.UI;
//using Kendo.Mvc.Extensions;

//namespace DaysProject5.Controllers
//{
//    public class TheatersController : Controller
//    {
//        private TheaterService ts;

//        public TheatersController()
//        {
//            ts = new TheaterService();
//        }

//        // GET: Theaters
//        public ActionResult Index()
//        {
//            return View(ts.GetData());
//        }

//        public ActionResult LaunchWindow()
//        {
//            return PartialView("LaunchWindowCreate");
//        }

//        public ActionResult Custom_Read([DataSourceRequest] DataSourceRequest request)
//        {
//            return Json(ts.Read().ToDataSourceResult(request));
//        }

//        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
//        {
//            DataSourceResult result = ts.Read().ToDataSourceResult(request, Thtr => new Theater
//            {
//                ID = Thtr.ID,
//                Name = Thtr.Name,
//                Capacity = Thtr.Capacity,
//                City = Thtr.City,
//                Class = Thtr.Class
//            });
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult EditingInline_Update([DataSourceRequest] DataSourceRequest request, Movie obj)
//        {
//            if (ModelState.IsValid)
//            {
//                ts.EditData(obj);
//            }
//            return Json(new[] { obj }.ToDataSourceResult(request, ModelState));
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult EditingInline_Destroy([DataSourceRequest] DataSourceRequest request, Movie obj)
//        {
//            if (obj != null)
//            {
//                ts.DestroyData(obj);
//            }

//            return Json(new[] { obj }.ToDataSourceResult(request, ModelState));
//        }

//        // GET: Theaters/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Movie theater = ts.FindData(id);
//            if (theater == null)
//            {
//                return HttpNotFound();
//            }
//            return View(theater);
//        }

//        // GET: Theaters/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Theaters/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        public ActionResult Create([Bind(Include = "ID,Name,Capacity,City,Class")] Movie theater)
//        {
//            if (ModelState.IsValid)
//            {
//                ts.CreateData(theater);
//                return RedirectToAction("Index");
//            }

//            return View(theater);
//        }

//        // GET: Theaters/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Movie theater = ts.FindData(id);
//            if (theater == null)
//            {
//                return HttpNotFound();
//            }
//            return View(theater);
//        }

//        // POST: Theaters/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        public ActionResult EditTheater([Bind(Include = "ID,Name,Capacity,City,Class")] Movie theater)
//        {
//            if (ModelState.IsValid)
//            {
//                ts.EditData(theater);
//                return RedirectToAction("Index");
//            }
//            return View(theater);
//        }

//        // GET: Theaters/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Movie theater = ts.FindData(id);
//            if (theater == null)
//            {
//                return HttpNotFound();
//            }
//            return View(theater);
//        }

//        // POST: Theaters/Delete/5
//        [HttpPost]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            ts.DeleteData(id);
//            return RedirectToAction("Index");
//        }
//    }
//}
