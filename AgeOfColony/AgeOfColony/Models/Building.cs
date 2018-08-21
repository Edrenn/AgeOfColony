using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{

    public abstract class Building : ViewableObject
    {
        public String Name { get; set; }
        [Range(0, 5)]
        public int Level { get; set; }
        [Range(5,5)]
        public int MaxLevel { get; set; }
        public List<LevelRequirement> Requirement { get; set; }
        public bool isBought { get; set; }
        public Game ParentGame { get; set; }

        protected Building(string name, int level, int maxLevel, List<LevelRequirement> requirement, bool isBought)
        {
            Name = name;
            Level = level;
            MaxLevel = maxLevel;
            Requirement = requirement;
            this.isBought = isBought;
        }

        public Building()
        {

        }
    }
}