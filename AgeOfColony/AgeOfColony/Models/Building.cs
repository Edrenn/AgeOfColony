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
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public Dictionary<int, LevelRequirement> Requirement { get; set; }

    }
}