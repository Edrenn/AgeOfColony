using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class MainBuilding : Building
    {
        public Resource TypeResource { get; set; }
        public float HarvestSpeed { get; set; }
        

    }
}