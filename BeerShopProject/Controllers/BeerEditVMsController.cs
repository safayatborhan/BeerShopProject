using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeerShopProject.Models;

namespace BeerShopProject.Controllers
{
    public class BeerEditVMsController : Controller
    {
        private BeerDBContext db = new BeerDBContext();

        // GET: BeerEditVMs
        public ActionResult Index()
        {
            return View(db.BeerDB.ToList());
        }

        //a method for returnig json formatted data
        public JsonResult IndexForJson()
        {
            return Json(db.BeerDB.ToList(),JsonRequestBehavior.AllowGet);
        }

        //a method for posting json data into server side
        [HttpPost]
        public ActionResult AddBearIntoDB(BeerEditVM model)
        {
            var beer = new BeerEditVM();
            beer.Name = model.Name;
            beer.Color = model.Color;
            beer.HasTried = model.HasTried;        
            if(ModelState.IsValid)
            {
                db.BeerDB.Add(beer);
                db.SaveChanges();
            }
            return Json(beer, JsonRequestBehavior.AllowGet);
        }

        // GET: BeerEditVMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerEditVM beerEditVM = db.BeerDB.Find(id);
            if (beerEditVM == null)
            {
                return HttpNotFound();
            }
            return View(beerEditVM);
        }

        // GET: BeerEditVMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeerEditVMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Color,HasTried")] BeerEditVM beerEditVM)
        {
            if (ModelState.IsValid)
            {
                db.BeerDB.Add(beerEditVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beerEditVM);
        }

        // GET: BeerEditVMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerEditVM beerEditVM = db.BeerDB.Find(id);
            if (beerEditVM == null)
            {
                return HttpNotFound();
            }
            return View(beerEditVM);
        }

        // POST: BeerEditVMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Color,HasTried")] BeerEditVM beerEditVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beerEditVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beerEditVM);
        }

        // GET: BeerEditVMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerEditVM beerEditVM = db.BeerDB.Find(id);
            if (beerEditVM == null)
            {
                return HttpNotFound();
            }
            return View(beerEditVM);
        }

        // POST: BeerEditVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BeerEditVM beerEditVM = db.BeerDB.Find(id);
            db.BeerDB.Remove(beerEditVM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
