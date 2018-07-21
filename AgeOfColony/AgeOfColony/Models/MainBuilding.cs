using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class MainBuilding : Building
    {
        public Resource TypeRessource { get; set; }
        public float HarvestSpeed { get; set; }
    }
}