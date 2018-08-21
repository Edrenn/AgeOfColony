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
    public class ResourcesController : Controller
    {
        private DBManager db = new DBManager();

        // GET: Resources
        public async Task<ActionResult> Index()
        {
            var resources = db.Resources.Include(r => r.RareVersion);
            return View(await resources.ToListAsync());
        }

        // GET: Resources/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = await db.Resources.Include(r => r.RareVersion).Where(rc => rc.Id == id).FirstAsync();
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            ViewBag.RareResourceId = new SelectList(db.RareResources, "Id", "Name");
            return View();
        }

        // POST: Resources/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,RarePercentage,ImgUrl")] Resource resource, int RareResourceId)
        {
            if (ModelState.IsValid)
            {
                resource.RareVersion = db.RareResources.Where(r => r.Id == RareResourceId).First();
                db.Resources.Add(resource);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(resource);
        }

        // GET: Resources/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = await db.Resources.FindAsync(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.RareResourceId = new SelectList(db.RareResources, "Id", "Name", resource.RareVersion);
            return View(resource);
        }

        // POST: Resources/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,RarePercentage,RareResourceId,ImgUrl")] Resource resource,int RareResourceId)
        {
            if (ModelState.IsValid)
            {
                
                Resource realR = await db.Resources.Include(r => r.RareVersion).Where(r => r.Id == resource.Id).FirstAsync();
                db.RareResources.Attach(realR.RareVersion);
                db.Entry(realR).CurrentValues.SetValues(resource);
                realR.RareVersion = db.RareResources.Where(r => r.Id == RareResourceId).First();

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RareResourceId = new SelectList(db.RareResources, "Id", "Name", resource.RareVersion);
            return View(resource);
        }

        // GET: Resources/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = await db.Resources.Include(r => r.RareVersion).Where(r => r.Id == id).FirstAsync();
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Resource resource = await db.Resources.FindAsync(id);
            db.Resources.Remove(resource);
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
