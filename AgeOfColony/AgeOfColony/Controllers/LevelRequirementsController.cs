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
    public class LevelRequirementsController : Controller
    {
        private DBManager db = new DBManager();

        // GET: LevelRequirements
        public async Task<ActionResult> Index()
        {
            return View(await db.LevelRequirements.ToListAsync());
        }

        // GET: LevelRequirements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelRequirement levelRequirement = await db.LevelRequirements.FindAsync(id);
            if (levelRequirement == null)
            {
                return HttpNotFound();
            }
            return View(levelRequirement);
        }

        // GET: LevelRequirements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelRequirements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] LevelRequirement levelRequirement)
        {
            if (ModelState.IsValid)
            {
                db.LevelRequirements.Add(levelRequirement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(levelRequirement);
        }

        // GET: LevelRequirements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelRequirement levelRequirement = await db.LevelRequirements.FindAsync(id);
            if (levelRequirement == null)
            {
                return HttpNotFound();
            }
            return View(levelRequirement);
        }

        // POST: LevelRequirements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] LevelRequirement levelRequirement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelRequirement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(levelRequirement);
        }

        // GET: LevelRequirements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelRequirement levelRequirement = await db.LevelRequirements.FindAsync(id);
            if (levelRequirement == null)
            {
                return HttpNotFound();
            }
            return View(levelRequirement);
        }

        // POST: LevelRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LevelRequirement levelRequirement = await db.LevelRequirements.FindAsync(id);
            db.LevelRequirements.Remove(levelRequirement);
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
