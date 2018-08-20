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
            var levelRequirement = db.LevelRequirements.Include(lr => lr.RequiredResources);
            return View(await levelRequirement.ToListAsync());
        }

        // GET: LevelRequirements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelRequirement levelRequirement = await db.LevelRequirements.Include(lr => lr.RequiredResources).FirstAsync();
            if (levelRequirement == null)
            {
                return HttpNotFound();
            }
            return View(levelRequirement);
        }

        // GET: LevelRequirements/Create
        public ActionResult Create()
        {
            List<SelectListItem> sliList = new List<SelectListItem>();
            foreach (var item in db.CollectedResources.Include(cr => cr.Resource))
            {
                sliList.Add(new SelectListItem()
                {
                    Selected = false,
                    Text = item.Quantity + "," + item.Resource.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.CollectedResourcesList = sliList;
            return View();
        }

        // POST: LevelRequirements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Level")] LevelRequirement levelRequirement,List<int> requiredResources)
        {
            if (ModelState.IsValid)
            {
                levelRequirement.RequiredResources = await db.CollectedResources.Where(cr => requiredResources.Contains(cr.Id)).ToListAsync();
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
            LevelRequirement levelRequirement = await db.LevelRequirements.Include(lr => lr.RequiredResources).FirstAsync();
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Level")] LevelRequirement levelRequirement, List<int> collectedResources)
        {
            if (ModelState.IsValid)
            {
                LevelRequirement realLR = await db.LevelRequirements.Include(lr => lr.RequiredResources).Where(lr => lr.Id == levelRequirement.Id).FirstAsync();
                foreach (CollectedResource cr in levelRequirement.RequiredResources)
                {
                    db.CollectedResources.Attach(cr);
                }
                db.Entry(realLR).CurrentValues.SetValues(levelRequirement);
                realLR.RequiredResources = await db.CollectedResources.Include(r => r.Resource).Where(r => collectedResources.Contains(r.Id)).ToListAsync();
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
