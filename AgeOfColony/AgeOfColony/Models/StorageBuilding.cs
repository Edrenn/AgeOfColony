using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class StorageBuilding : Building
    {
        public Resource TypeResource { get; set; }
        public int MaxStorage { get; set; }
    }
}