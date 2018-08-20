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
    public class CollectedResourcesController : Controller
    {
        private DBManager db = new DBManager();

        // GET: CollectedResources
        public async Task<ActionResult> Index()
        {
            var collectedResources = db.CollectedResources.Include(cr => cr.Resource);
            return View(await collectedResources.ToListAsync());
        }

        // GET: CollectedResources/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectedResource collectedResource = await db.CollectedResources.Include(cr => cr.Resource).Where(cr => cr.Id == id).FirstAsync();
            if (collectedResource == null)
            {
                return HttpNotFound();
            }
            return View(collectedResource);
        }

        // GET: CollectedResources/Create
        public ActionResult Create()
        {
            ViewBag.Resources = new SelectList(db.Resources, "Id", "Name");
            return View();
        }

        // POST: CollectedResources/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Quantity")] CollectedResource collectedResource,int Resources)
        {
            if (ModelState.IsValid)
            {
                collectedResource.Resource = db.Resources.Where(r => r.Id == Resources).First();
                db.CollectedResources.Add(collectedResource);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(collectedResource);
        }

        // GET: CollectedResources/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Resources = new SelectList(db.Resources, "Id", "Name");
            CollectedResource collectedResource = await db.CollectedResources.Include(cr => cr.Resource).FirstAsync();
            if (collectedResource == null)
            {
                return HttpNotFound();
            }
            return View(collectedResource);
        }

        // POST: CollectedResources/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Quantity")] CollectedResource collectedResource, int Resources)
        {
            if (ModelState.IsValid)
            {

                CollectedResource realCR = await db.CollectedResources.Include(r => r.Resource).Where(cr => cr.Id == collectedResource.Id).FirstAsync();
                db.Resources.Attach(realCR.Resource);
                db.Entry(realCR).CurrentValues.SetValues(collectedResource);
                realCR.Resource = db.Resources.Where(r => r.Id == Resources).First();
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(collectedResource);
        }

        // GET: CollectedResources/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectedResource collectedResource = await db.CollectedResources.FindAsync(id);
            if (collectedResource == null)
            {
                return HttpNotFound();
            }
            return View(collectedResource);
        }

        // POST: CollectedResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CollectedResource collectedResource = await db.CollectedResources.FindAsync(id);
            db.CollectedResources.Remove(collectedResource);
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
