using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DD.TrafficLight.Web.Models;

namespace DD.TrafficLight.Web.Controllers
{
    public class TrafficLightConfigurationsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: TrafficLightConfigurations
        public ActionResult Index()
        {
            return View(_db.TrafficLightConfigurations.ToList());
        }

        // GET: TrafficLightConfigurations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trafficLightConfiguration = _db.TrafficLightConfigurations.Find(id);
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
        public ActionResult Create(
            [Bind(Include = "TrafficLightID,Red,Green,Yellow,MaintenanceMode")] TrafficLightConfiguration
                trafficLightConfiguration)
        {
            if (ModelState.IsValid)
            {
                _db.TrafficLightConfigurations.Add(trafficLightConfiguration);
                _db.SaveChanges();
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
            var trafficLightConfiguration = _db.TrafficLightConfigurations.Find(id);
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
        public ActionResult Edit(
            [Bind(Include = "TrafficLightID,Red,Green,Yellow,MaintenanceMode")] TrafficLightConfiguration
                trafficLightConfiguration)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(trafficLightConfiguration).State = EntityState.Modified;
                _db.SaveChanges();
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
            var trafficLightConfiguration = _db.TrafficLightConfigurations.Find(id);
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
            var trafficLightConfiguration = _db.TrafficLightConfigurations.Find(id);
            _db.TrafficLightConfigurations.Remove(trafficLightConfiguration);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}