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
    [Authorize(Roles = RoleType.Admin)]
    public class MainBuildingsController : Controller
    {
        private DBManager db = new DBManager();

        // GET: MainBuildings
        public ActionResult Index()
        {
            var mainBuildings = db.MainBuildings.Include(r => r.TypeResource);
            return View(mainBuildings.ToList());
        }

        // GET: MainBuildings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainBuilding mainBuilding = await db.MainBuildings.Include(a => a.TypeResource).Where(a => a.Id == id).FirstAsync();
            if (mainBuilding == null)
            {
                return HttpNotFound();
            }
            return View(mainBuilding);
        }

        // GET: MainBuildings/Create
        public ActionResult Create()
        {
            ViewBag.TypeResource = new SelectList(db.Resources, "Id", "Name");
            return View();
        }

        // POST: MainBuildings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HarvestSpeed,Name,Level,MaxLevel,ResourceId,isBought,ImgUrl")] MainBuilding mainBuilding, int TypeResource)
        {
            if (ModelState.IsValid)
            {
                mainBuilding.TypeResource = db.Resources.Where(r => r.Id == TypeResource).First();
                db.MainBuildings.Add(mainBuilding);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mainBuilding);
        }

        // GET: MainBuildings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.TypeResource = new SelectList(db.Resources, "Id", "Name");
            MainBuilding mainBuilding = await db.MainBuildings.Include(hb => hb.TypeResource).Where(hb => hb.Id == id).FirstAsync();
            if (mainBuilding == null)
            {
                return HttpNotFound();
            }
            return View(mainBuilding);
        }

        // POST: MainBuildings/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,HarvestSpeed,Name,Level,MaxLevel,isBought,ImgUrl")] MainBuilding mainBuilding, int TypeResource)
        {
            if (ModelState.IsValid)
            {
                MainBuilding realHB = await db.MainBuildings.Include(hb => hb.TypeResource).Where(hb => hb.Id == mainBuilding.Id).FirstAsync();
                db.Resources.Attach(realHB.TypeResource);
                db.Entry(realHB).CurrentValues.SetValues(mainBuilding);
                realHB.TypeResource = db.Resources.Include(r => r.RareVersion).Where(r => r.Id == TypeResource).First();
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(mainBuilding);
        }

        // GET: MainBuildings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainBuilding mainBuilding = await db.MainBuildings.Include(hb => hb.TypeResource).Where(hb => hb.Id == id).FirstAsync();
            if (mainBuilding == null)
            {
                return HttpNotFound();
            }
            return View(mainBuilding);
        }

        // POST: MainBuildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MainBuilding mainBuilding = await db.MainBuildings.FindAsync(id);
            db.MainBuildings.Remove(mainBuilding);
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
