using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class DBManager : DbContext
    {
        public DBManager()
    : base("GameConnection")
        {
            // Put code to recreate db
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AgeOfColony.Models.CollectedResource> CollectedResources { get; set; }

        public System.Data.Entity.DbSet<AgeOfColony.Models.Game> Games { get; set; }

        public System.Data.Entity.DbSet<AgeOfColony.Models.HarvestBuilding> HarvestBuildings { get; set; }

        public System.Data.Entity.DbSet<AgeOfColony.Models.LevelRequirement> LevelRequirements { get; set; }

        public System.Data.Entity.DbSet<AgeOfColony.Models.MainBuilding> MainBuildings { get; set; }

        public System.Data.Entity.DbSet<AgeOfColony.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<AgeOfColony.Models.Resource> Resources { get; set; }

        public System.Data.Entity.DbSet<AgeOfColony.Models.StorageBuilding> StorageBuildings { get; set; }

        public System.Data.Entity.DbSet<AgeOfColony.Models.RareResource> RareResources { get; set; }
    }
}