using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class Game : BaseObject
    {
        public List<Building> AllBuildings { get; set; }
        public List<CollectedResource> AllRessources { get; set; }
        public DateTime LastSave { get; set; }

        public Game(List<Building> allBuildings, List<CollectedResource> allRessources)
        {
            AllBuildings = allBuildings;
            AllRessources = allRessources;
        }

        public Game()
        {

        }
    }
}