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
    public class RareResourcesController : Controller
    {
        private DBManager db = new DBManager();

        // GET: RareResources
        public async Task<ActionResult> Index()
        {
            return View(await db.RareResources.ToListAsync());
        }

        // GET: RareResources/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RareResource rareResource = await db.RareResources.FindAsync(id);
            if (rareResource == null)
            {
                return HttpNotFound();
            }
            return View(rareResource);
        }

        // GET: RareResources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RareResources/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ImgUrl")] RareResource rareResource)
        {
            if (ModelState.IsValid)
            {
                db.RareResources.Add(rareResource);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rareResource);
        }

        // GET: RareResources/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RareResource rareResource = await db.RareResources.FindAsync(id);
            if (rareResource == null)
            {
                return HttpNotFound();
            }
            return View(rareResource);
        }

        // POST: RareResources/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ImgUrl")] RareResource rareResource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rareResource).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rareResource);
        }

        // GET: RareResources/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RareResource rareResource = await db.RareResources.FindAsync(id);
            if (rareResource == null)
            {
                return HttpNotFound();
            }
            return View(rareResource);
        }

        // POST: RareResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RareResource rareResource = await db.RareResources.FindAsync(id);
            db.RareResources.Remove(rareResource);
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
