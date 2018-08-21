using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class MainBuilding : Building
    {
        public Resource TypeResource { get; set; }
        [Range(10,20)]
        public float HarvestSpeed { get; set; }
        [Range(0.1,0.5)]
        public float HarvestSpeedCoef { get; set; }

        public MainBuilding(string name, int level, int maxLevel, bool isBought, Resource typeResource, float harvestSpeed,float harvestSpeedCoef, List<LevelRequirement> requirements = null)
            : base(name,level,maxLevel, requirements, isBought)
        {
            TypeResource = typeResource;
            HarvestSpeed = harvestSpeed;
            HarvestSpeedCoef = harvestSpeedCoef;
        }

        public MainBuilding()
        {

        }
    }
}