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
            this.Database.CreateIfNotExists();
            if (!this.Database.CompatibleWithModel(false))
            {
                this.Database.Delete();
                this.Database.CreateIfNotExists();
                // Rare Resources
                RareResource boBois = new RareResource() { Name = "DuBoBois" };
                this.RareResources.Add(boBois);
                RareResource boFer = new RareResource() { Name = "DuBoFer" };
                this.RareResources.Add(boFer);
                RareResource boPierre = new RareResource() { Name = "DuBoPierre" };
                this.RareResources.Add(boPierre);
                // Resources
                Resource bois = new Resource() { Name = "Bois", RarePercentage = 1, RareVersion = boBois };
                this.Resources.Add(bois);
                Resource fer = new Resource() { Name = "Fer", RarePercentage = 1, RareVersion = boFer };
                this.Resources.Add(bois);
                Resource pierre = new Resource() { Name = "Pierre", RarePercentage = 1, RareVersion = boPierre };
                this.Resources.Add(bois);
                // Collected Resource
                CollectedResource cr1 = new CollectedResource() { Resource = bois, Quantity = 100 };
                // Level Requirement
                LevelRequirement lr = new LevelRequirement() { Level = 1, RequiredResources = new List<CollectedResource>() { cr1 } };
                // HarvestBuilder
                HarvestBuilding hb = new HarvestBuilding()
                {
                    Name = "Syrie",
                    CurrentPeople = 0,
                    HarvestQuantity = 1,
                    HarvestTime = 1,
                    ImgUrl = "",
                    isBought = false,
                    Level = 1,
                    MaxLevel = 20,
                    MaxPeople = 10,
                    MaxStorage = 100,
                    TypeResource = bois,
                    Requirement = new List<LevelRequirement>() { lr }
                };
            }
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