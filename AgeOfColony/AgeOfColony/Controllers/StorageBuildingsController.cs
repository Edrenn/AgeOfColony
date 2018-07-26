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
    public class StorageBuildingsController : Controller
    {
        private DBManager db = new DBManager();

        // GET: StorageBuildings
        public async Task<ActionResult> Index()
        {
            return View(await db.StorageBuildings.ToListAsync());
        }

        // GET: StorageBuildings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageBuilding storageBuilding = await db.StorageBuildings.FindAsync(id);
            if (storageBuilding == null)
            {
                return HttpNotFound();
            }
            return View(storageBuilding);
        }

        // GET: StorageBuildings/Create
        public ActionResult Create()
        {
            ViewBag.TypeResource = new SelectList(db.Resources, "Id", "Name");
            return View();
        }

        // POST: StorageBuildings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,MaxStorage,Name,Level,MaxLevel,ImgUrl")] StorageBuilding storageBuilding,int TypeResource)
        {
            if (ModelState.IsValid)
            {
                storageBuilding.TypeRessource = db.Resources.Where(r => r.Id == TypeResource).First();
                db.StorageBuildings.Add(storageBuilding);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(storageBuilding);
        }

        // GET: StorageBuildings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.TypeResource = new SelectList(db.Resources, "Id", "Name");
            StorageBuilding storageBuilding = await db.StorageBuildings.Include(sb => sb.TypeRessource).Where(sb => sb.Id == id).FirstAsync();
            if (storageBuilding == null)
            {
                return HttpNotFound();
            }
            return View(storageBuilding);
        }

        // POST: StorageBuildings/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,MaxStorage,Name,Level,MaxLevel,ImgUrl")] StorageBuilding storageBuilding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storageBuilding).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(storageBuilding);
        }

        // GET: StorageBuildings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageBuilding storageBuilding = await db.StorageBuildings.FindAsync(id);
            if (storageBuilding == null)
            {
                return HttpNotFound();
            }
            return View(storageBuilding);
        }

        // POST: StorageBuildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StorageBuilding storageBuilding = await db.StorageBuildings.FindAsync(id);
            db.StorageBuildings.Remove(storageBuilding);
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
