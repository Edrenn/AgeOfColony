using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class HarvestBuilding : Building
    {
        public Resource TypeRessource { get; set; }
        public int MaxStorage { get; set; }
        public float HarvestTime { get; set; }
        public int HarvestQuantity { get; set; }
        public int CurrentPeople { get; set; }
        public int MaxPeople { get; set; }
    }
}