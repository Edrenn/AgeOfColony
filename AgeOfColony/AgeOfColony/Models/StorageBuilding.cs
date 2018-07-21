using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class StorageBuilding : Building
    {
        public Resource TypeRessource { get; set; }
        public int MaxStorage { get; set; }
    }
}