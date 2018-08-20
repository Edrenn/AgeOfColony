﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{

    public abstract class Building : ViewableObject
    {
        public String Name { get; set; }
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public List<LevelRequirement> Requirement { get; set; }
        public bool isBought { get; set; }

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