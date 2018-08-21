using AgeOfColony.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AgeOfColony.Controllers
{
    public class GameplayController : Controller
    {
        private static Game currentGame;
        public static Game CurrentGame
        {
            get
            {
                if (currentGame == null)
                {
                    GameModel gm = new GameModel();
                    currentGame = new Game();
                }
                return currentGame;
            }
        }
        
        public ActionResult Index()
        {
            GameModel gm = new GameModel();
            Game game =  gm.GetNewGameWithoutPersisting();
            currentGame = game;
            return View(game);
        } 

        [HttpPost]
        public ActionResult MainBuilding()
        {
            return PartialView("Buildings/_MainBuilding");
        }

        [HttpPost]
        public ActionResult ChangeBuildlingView(int buildingId)
        {
            return PartialView("Buildings/_Harvester",CurrentGame.AllBuildings.Where(b => b.Id == buildingId).First());
        }

        [HttpPost]
        public int BuyHuman()
        {
            CurrentGame.AllRessources.Where(cr => cr.Resource.Name == ResourceType.Human).First().Quantity++;
            return 1;
        }
        
        public static void LaunchAllProduction()
        {
            foreach (Building building in currentGame.AllBuildings)
            {
                if (building is HarvestBuilding)
                {
                    HarvestBuilding hb = (HarvestBuilding)building;
                    if (hb.isBought)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            Produce((HarvestBuilding)building);
                        });
                    }
                }
            }
        }

        public static void Produce(HarvestBuilding hb)
        {
            int newProduction = hb.HarvestQuantity * (hb.CurrentPeople + 1);
            CurrentGame.AllRessources.Where(r => r.Resource.Name == hb.TypeResource.Name).First().Quantity += newProduction;
            Thread.Sleep(hb.HarvestTime * 1000);
            Produce(hb);
        }

        public ActionResult GetCollectedResources()
        {
            return PartialView("_ResourceBar", CurrentGame.AllRessources);
        }
    }
}