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
        private DBManager db = new DBManager();

        // GET: HarvestBuildings
        public async Task<ActionResult> Index()
        {
            var harvestBuildings = db.HarvestBuildings.Include(r => r.TypeResource);
            return View(await harvestBuildings.ToListAsync());
        }

        // GET: HarvestBuildings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HarvestBuilding harvestBuilding = await db.HarvestBuildings.Include(hb => hb.TypeResource).Where(hb => hb.Id == id).FirstAsync();
            if (harvestBuilding == null)
            {
                return HttpNotFound();
            }
            return View(harvestBuilding);
        }

        // GET: HarvestBuildings/Create
        public ActionResult Create()
        {
            //ViewBag.Resources = await db.Resources.ToListAsync();
            ViewBag.TypeResource = new SelectList(db.Resources, "Id", "Name");
            return View();
        }

        // POST: HarvestBuildings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaxStorage,HarvestTime,HarvestQuantity,CurrentPeople,MaxPeople,Name,Level,MaxLevel,ImgUrl")] HarvestBuilding harvestBuilding,int TypeResource)
        {
            if (ModelState.IsValid)
            {
                harvestBuilding.TypeResource = db.Resources.Where(r => r.Id == TypeResource).First();
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
            ViewBag.TypeResource = new SelectList(db.Resources, "Id", "Name");
            HarvestBuilding harvestBuilding = await db.HarvestBuildings.Include(hb => hb.TypeResource).Where(hb => hb.Id == id).FirstAsync();
            harvestBuilding.TypeResource = db.Resources.Where(r => r.Id == harvestBuilding.TypeResource.Id).First();
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,MaxStorage,HarvestTime,HarvestQuantity,CurrentPeople,MaxPeople,ResourceId,Name,Level,MaxLevel,ImgUrl")] HarvestBuilding harvestBuilding)
        {
            if (ModelState.IsValid)
            {

                //harvestBuilding.TypeResource = db.Resources.Where(r => r.Id == harvestBuilding.ResourceId).First();
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
            HarvestBuilding harvestBuilding = await db.HarvestBuildings.Include(hb => hb.TypeResource).Where(hb => hb.Id == id).FirstAsync();
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
