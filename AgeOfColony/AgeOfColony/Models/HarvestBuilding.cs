using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class HarvestBuilding : Building
    {

        [Range(10,1000)]
        public int MaxStorage { get; set; }
        public int StorageCoef { get; set; }
        [Range(10,30)]
        public int HarvestTime { get; set; }
        [Range(10, 30)]
        public int HarvestQuantity { get; set; }
        public int HarvestQuantityCoef { get; set; }
        [Range(0,10)]
        public int CurrentPeople { get; set; }
        [Range(10, 30)]
        public int MaxPeople { get; set; }
        public int MaxPeopleCoef { get; set; }

        public Resource TypeResource { get; set; }

        public HarvestBuilding(string name,int level, int maxLevel,bool isBought, int maxStorage, int storageCoef, int harvestTime,
            int harvestQuantity, int harvestQuantityCoef,int currentPeople, int maxPeople, int maxPeopleCoef,
            Resource typeResource, List<LevelRequirement> levelRequirements = null)
            : base(name,level, maxLevel, levelRequirements, isBought)
        {
            MaxStorage = maxStorage;
            StorageCoef = storageCoef;
            HarvestTime = harvestTime;
            HarvestQuantity = harvestQuantity;
            HarvestQuantityCoef = harvestQuantityCoef;
            CurrentPeople = currentPeople;
            MaxPeople = maxPeople;
            MaxPeopleCoef = maxPeopleCoef;
            TypeResource = typeResource;
        }

        public HarvestBuilding()
        {

        }
    }
}