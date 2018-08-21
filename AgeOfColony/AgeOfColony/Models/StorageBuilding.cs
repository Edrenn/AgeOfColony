using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class StorageBuilding : Building
    {
        public Resource TypeResource { get; set; }
        [Range(0,1000)]
        public int MaxStorage { get; set; }
        [Range(0, 200)]
        public int MaxStorageCoef { get; set; } 

        public StorageBuilding(string name, int level, int maxLevel, bool isBought, Resource typeResource, int maxStorage, int maxStorageCoef, List<LevelRequirement> requirements = null)
            : base(name, level, maxLevel, requirements, isBought)
        {
            TypeResource = typeResource;
            MaxStorage = maxStorage;
            MaxStorageCoef = maxStorageCoef;
        }

        public StorageBuilding()
        {

        }
    }
}