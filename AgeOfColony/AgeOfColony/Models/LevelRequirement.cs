using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class LevelRequirement : BaseObject
    {
        public List<CollectedResource> RequiredResources { get; set; }
        public int Level { get; set; }

        public LevelRequirement(int level, List<CollectedResource> requiredResources)
        {
            RequiredResources = requiredResources;
            Level = level;
        }

        public LevelRequirement()
        {

        }
    }
}