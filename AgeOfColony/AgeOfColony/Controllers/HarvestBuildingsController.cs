using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgeOfColony.Models;

namespace AgeOfColony.Controllers
{
    public class HarvestBuildingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HarvestBuildings
        public async Task<ActionResult> Index()
        {
            return View(await db.HarvestBuildings.ToListAsync());
        }

        // GET: HarvestBuildings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HarvestBuilding harvestBuilding = await db.HarvestBuildings.FindAsync(id);
            if (harvestBuilding == null)
            {
                return HttpNotFound();
            }
            return View(harvestBuilding);
        }

        // GET: HarvestBuildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HarvestBuildings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,MaxStorage,HarvestTime,HarvestQuantity,CurrentPeople,MaxPeople,Name,Level,MaxLevel,ImgUrl")] HarvestBuilding harvestBuilding)
        {
            if (ModelState.IsValid)
            {
                db.HarvestBuildings.Add(harvestBuilding);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(harvestBuilding);
        }

        // GET: HarvestBuildings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HarvestBuilding harvestBuilding = await db.HarvestBuildings.FindAsync(id);
            if (harvestBuilding == null)
            {
                return HttpNotFound();
            }
            return View(harvestBuilding);
        }

        // POST: HarvestBuildings/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,MaxStorage,HarvestTime,HarvestQuantity,CurrentPeople,MaxPeople,Name,Level,MaxLevel,ImgUrl")] HarvestBuilding harvestBuilding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(harvestBuilding).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(harvestBuilding);
        }

        // GET: HarvestBuildings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HarvestBuilding harvestBuilding = await db.HarvestBuildings.FindAsync(id);
            if (harvestBuilding == null)
            {
                return HttpNotFound();
            }
            return View(harvestBuilding);
        }

        // POST: HarvestBuildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HarvestBuilding harvestBuilding = await db.HarvestBuildings.FindAsync(id);
            db.HarvestBuildings.Remove(harvestBuilding);
            await db.SaveChangesAsync();
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
