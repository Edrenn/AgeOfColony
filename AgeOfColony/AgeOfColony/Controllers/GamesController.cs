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
    public class GamesController : Controller
    {
        private DBManager db = new DBManager();

        // GET: Games
        public async Task<ActionResult> Index()
        {
            var games = await db.Games.Include(lr => lr.AllBuildings).Include(p => p.AllRessources).ToListAsync();
            return View(games);
        }

        // GET: Games/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            List<Building> buildings = new List<Building>();
            buildings.AddRange(db.HarvestBuildings.Where(r => r.ParentGame == null));
            buildings.AddRange(db.MainBuildings.Where(r => r.ParentGame == null));
            buildings.AddRange(db.StorageBuildings.Where(r => r.ParentGame == null));
            ViewBag.BuildingList = buildings;
            List<CollectedResource> resources = new List<CollectedResource>();
            resources = ViewBag.ResourcesList = db.CollectedResources.Include(cr => cr.Resource).ToList();
            return View();
        }

        // POST: Games/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] Game game, string[] build)
        {
            if (ModelState.IsValid)
            {
                List<int> buildings = new List<int>();
                foreach (string item in build)
                {
                    int leOut = 0;
                    if (Int32.TryParse(item, out leOut))
                    {
                        buildings.Add(leOut);
                    }
                }
                List<Building> builds = new List<Building>();
                builds.AddRange(await db.HarvestBuildings.Where(r => buildings.Contains(r.Id)).ToListAsync());
                builds.AddRange(await db.MainBuildings.Where(r => buildings.Contains(r.Id)).ToListAsync());
                builds.AddRange(await db.StorageBuildings.Where(r => buildings.Contains(r.Id)).ToListAsync());
                game.AllBuildings = builds;
                db.Games.Add(game);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Game game = await db.Games.FindAsync(id);
            db.Games.Remove(game);
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
