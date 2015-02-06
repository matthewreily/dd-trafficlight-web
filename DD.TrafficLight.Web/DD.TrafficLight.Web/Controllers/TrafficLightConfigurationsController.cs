using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DD.TrafficLight.Web.Models;

namespace DD.TrafficLight.Web.Controllers
{
    public class TrafficLightConfigurationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrafficLightConfigurations
        public ActionResult Index()
        {
            return View(db.TrafficLightConfigurations.ToList());
        }

        // GET: TrafficLightConfigurations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficLightConfiguration trafficLightConfiguration = db.TrafficLightConfigurations.Find(id);
            if (trafficLightConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(trafficLightConfiguration);
        }

        // GET: TrafficLightConfigurations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrafficLightConfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrafficLightID,Red,Green,Yellow,MaintenanceMode")] TrafficLightConfiguration trafficLightConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.TrafficLightConfigurations.Add(trafficLightConfiguration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trafficLightConfiguration);
        }

        // GET: TrafficLightConfigurations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficLightConfiguration trafficLightConfiguration = db.TrafficLightConfigurations.Find(id);
            if (trafficLightConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(trafficLightConfiguration);
        }

        // POST: TrafficLightConfigurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrafficLightID,Red,Green,Yellow,MaintenanceMode")] TrafficLightConfiguration trafficLightConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trafficLightConfiguration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trafficLightConfiguration);
        }

        // GET: TrafficLightConfigurations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficLightConfiguration trafficLightConfiguration = db.TrafficLightConfigurations.Find(id);
            if (trafficLightConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(trafficLightConfiguration);
        }

        // POST: TrafficLightConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrafficLightConfiguration trafficLightConfiguration = db.TrafficLightConfigurations.Find(id);
            db.TrafficLightConfigurations.Remove(trafficLightConfiguration);
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
