using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AgeOfColony.Models
{
    public class GameModel
    {
        private DBManager db = new DBManager();

        public GameModel()
        {
        }

        public async Task<Game> CreateNewGame(string id, string username)
        {

            #region Resources
            Tuple<List<RareResource>, List<Resource>> staticDatas = GetStaticData().Result;
            List<RareResource> allRareResources = staticDatas.Item1;
            RareResource rareWood = allRareResources.Where(rr => rr.Name == ResourceType.RareWood).First();
            RareResource rareStone = allRareResources.Where(rr => rr.Name == ResourceType.RareStone).First();
            RareResource rareIron = allRareResources.Where(rr => rr.Name == ResourceType.RareIron).First();
            RareResource rareOil = allRareResources.Where(rr => rr.Name == ResourceType.RareOil).First();
            RareResource rareElec = allRareResources.Where(rr => rr.Name == ResourceType.RareElectricity).First();
            #endregion

            #region RareResources
            List<Resource> allResources = staticDatas.Item2;
            Resource wood = allResources.Where(r => r.Name == ResourceType.Wood).First();
            Resource stone = allResources.Where(r => r.Name == ResourceType.Stone).First();
            Resource iron = allResources.Where(r => r.Name == ResourceType.Iron).First();
            Resource oil = allResources.Where(r => r.Name == ResourceType.Oil).First();
            Resource electricity = allResources.Where(r => r.Name == ResourceType.Electricity).First();
            Resource food = allResources.Where(r => r.Name == ResourceType.Food).First();
            Resource human = allResources.Where(r => r.Name == ResourceType.Human).First();
            #endregion

            #region CollectedResources
            List<CollectedResource> allCollectedResources = new List<CollectedResource>();
            CollectedResource collectedWood = new CollectedResource(wood, 0);
            allCollectedResources.Add(collectedWood);
            CollectedResource collectedStone = new CollectedResource(stone, 0);
            allCollectedResources.Add(collectedStone);
            CollectedResource collectedIron = new CollectedResource(iron, 0);
            allCollectedResources.Add(collectedIron);
            CollectedResource collectedOil = new CollectedResource(oil, 0);
            allCollectedResources.Add(collectedOil);
            CollectedResource collectedElectricity = new CollectedResource(electricity, 0);
            allCollectedResources.Add(collectedElectricity);
            CollectedResource collectedFood = new CollectedResource(food, 0);
            allCollectedResources.Add(collectedFood);
            CollectedResource collectedHuman = new CollectedResource(human, 0);
            allCollectedResources.Add(collectedHuman);

            db.CollectedResources.AddRange(allCollectedResources);
            await db.SaveChangesAsync();
            #endregion

            #region Buildings
            List<Building> allBuildings = new List<Building>();

            #region Harvester
            // Wood
            List<HarvestBuilding> allHarvestBuildings = new List<HarvestBuilding>();
            HarvestBuilding woodHarvester = new HarvestBuilding("scierie", 1, 5, true, 500,80, 1, 10,10, 0, 10,20, wood);
            woodHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(woodHarvester);

            // Stone
            HarvestBuilding stoneHarvester = new HarvestBuilding("carrière", 1, 5, true, 500, 80, 1, 10, 10, 0, 10, 20, stone);
            stoneHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(stoneHarvester);

            // Iron
            HarvestBuilding ironHarvester = new HarvestBuilding("mine de fer", 1, 5, false, 500, 80, 1, 10, 10, 0, 10, 20, iron);
            ironHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(ironHarvester);

            // Oil
            HarvestBuilding oilHarvester = new HarvestBuilding("pompe", 1, 5, false, 500, 80, 1, 10, 10, 0, 10, 20, oil);
            oilHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(oilHarvester);

            // Electricity
            HarvestBuilding electricityHarvester = new HarvestBuilding("centrale", 1, 5, false, 500, 80, 1, 10, 10, 0, 10, 20, electricity);
            electricityHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(electricityHarvester);

            // Food
            HarvestBuilding foodHarvester = new HarvestBuilding("chez léon", 1, 5, true, 500, 80, 1, 10, 10, 0, 10, 20, food);
            foodHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(foodHarvester);
            db.HarvestBuildings.AddRange(allHarvestBuildings);
            await db.SaveChangesAsync();
            allBuildings.AddRange(allHarvestBuildings);
            #endregion

            #region Storage
            List<StorageBuilding> allStorageBuildings = new List<StorageBuilding>();

            // Wood
            StorageBuilding woodStorage = new StorageBuilding("Abri-bois", 1, 5, false, wood, 1000,100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(woodStorage);

            // Stone
            StorageBuilding stoneStorage = new StorageBuilding("Entrepôt à caillou", 1, 5, false, stone, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(stoneStorage);

            // Iron
            StorageBuilding ironStorage = new StorageBuilding("Fer Ash'Fall", 1, 5, false, iron, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(ironStorage);

            // Oil
            StorageBuilding oilStorage = new StorageBuilding("Bidons", 1, 5, false, oil, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(oilStorage);

            // Electricity
            StorageBuilding electricityStorage = new StorageBuilding("Batteries", 1, 5, false, electricity, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(electricityStorage);

            // Food
            StorageBuilding foodStorage = new StorageBuilding("Frijdère", 1, 5, false, food, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(foodStorage);

            // Human
            StorageBuilding humanStorage = new StorageBuilding("maison", 1, 5, false, human, 10, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(humanStorage);
            db.StorageBuildings.AddRange(allStorageBuildings);
            await db.SaveChangesAsync();
            allBuildings.AddRange(allStorageBuildings);
            #endregion

            #region MainBuilding
            MainBuilding mainBuilding = new MainBuilding("Forum", 1, 0, true, human, 10,10)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            db.MainBuildings.Add(mainBuilding);
            await db.SaveChangesAsync();
            allBuildings.Add(mainBuilding);
            #endregion
            #endregion

            Game newGame = new Game(allBuildings, allCollectedResources);
            db.Games.Add(newGame);
            await db.SaveChangesAsync();

            Player p = new Player();
            p.LoginId = id;
            p.TheGame = newGame;
            p.Username = username;
            db.Players.Add(p);
            await db.SaveChangesAsync();

            return p.TheGame;
        }


        public Game GetNewGameWithoutPersisting()
        {

            #region Resources
            Tuple<List<RareResource>, List<Resource>> staticDatas = GetStaticData().Result;
            List<RareResource> allRareResources = staticDatas.Item1;
            RareResource rareWood = allRareResources.Where(rr => rr.Name == ResourceType.RareWood).First();
            RareResource rareStone = allRareResources.Where(rr => rr.Name == ResourceType.RareStone).First();
            RareResource rareIron = allRareResources.Where(rr => rr.Name == ResourceType.RareIron).First();
            RareResource rareOil = allRareResources.Where(rr => rr.Name == ResourceType.RareOil).First();
            RareResource rareElec = allRareResources.Where(rr => rr.Name == ResourceType.RareElectricity).First();
            #endregion

            #region RareResources
            List<Resource> allResources = staticDatas.Item2;
            Resource wood = allResources.Where(r => r.Name == ResourceType.Wood).First();
            Resource stone = allResources.Where(r => r.Name == ResourceType.Stone).First();
            Resource iron = allResources.Where(r => r.Name == ResourceType.Iron).First();
            Resource oil = allResources.Where(r => r.Name == ResourceType.Oil).First();
            Resource electricity = allResources.Where(r => r.Name == ResourceType.Electricity).First();
            Resource food = allResources.Where(r => r.Name == ResourceType.Food).First();
            Resource human = allResources.Where(r => r.Name == ResourceType.Human).First();
            #endregion

            #region CollectedResources
            List<CollectedResource> allCollectedResources = new List<CollectedResource>();
            CollectedResource collectedWood = new CollectedResource(wood, 0);
            allCollectedResources.Add(collectedWood);
            CollectedResource collectedStone = new CollectedResource(stone, 0);
            allCollectedResources.Add(collectedStone);
            CollectedResource collectedIron = new CollectedResource(iron, 0);
            allCollectedResources.Add(collectedIron);
            CollectedResource collectedOil = new CollectedResource(oil, 0);
            allCollectedResources.Add(collectedOil);
            CollectedResource collectedElectricity = new CollectedResource(electricity, 0);
            allCollectedResources.Add(collectedElectricity);
            CollectedResource collectedFood = new CollectedResource(food, 0);
            allCollectedResources.Add(collectedFood);
            CollectedResource collectedHuman = new CollectedResource(human, 0);
            allCollectedResources.Add(collectedHuman);
            #endregion

            #region Buildings
            List<Building> allBuildings = new List<Building>();

            #region Harvester
            // Wood
            List<HarvestBuilding> allHarvestBuildings = new List<HarvestBuilding>();
            HarvestBuilding woodHarvester = new HarvestBuilding("scierie", 1, 5, true, 500, 80, 1, 10, 10, 0, 10, 20, wood);
            woodHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(woodHarvester);

            // Stone
            HarvestBuilding stoneHarvester = new HarvestBuilding("carrière", 1, 5, true, 500, 80, 1, 10, 10, 0, 10, 20, stone);
            stoneHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(stoneHarvester);

            // Iron
            HarvestBuilding ironHarvester = new HarvestBuilding("mine de fer", 1, 5, false, 500, 80, 1, 10, 10, 0, 10, 20, iron);
            ironHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(ironHarvester);

            // Oil
            HarvestBuilding oilHarvester = new HarvestBuilding("pompe", 1, 5, false, 500, 80, 1, 10, 10, 0, 10, 20, oil);
            oilHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(oilHarvester);

            // Electricity
            HarvestBuilding electricityHarvester = new HarvestBuilding("centrale", 1, 5, false, 500, 80, 1, 10, 10, 0, 10, 20, electricity);
            electricityHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(electricityHarvester);

            // Food
            HarvestBuilding foodHarvester = new HarvestBuilding("chez léon", 1, 5, true, 500, 80, 1, 10, 10, 0, 10, 20, food);
            foodHarvester.Requirement = new List<LevelRequirement>()
            {
                new LevelRequirement(2, null),
                new LevelRequirement(3, null),
                new LevelRequirement(4, null),
                new LevelRequirement(5, null)
            };
            allHarvestBuildings.Add(foodHarvester);
            allBuildings.AddRange(allHarvestBuildings);
            #endregion

            #region Storage
            List<StorageBuilding> allStorageBuildings = new List<StorageBuilding>();

            // Wood
            StorageBuilding woodStorage = new StorageBuilding("Abri-bois", 1, 5, false, wood, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(woodStorage);

            // Stone
            StorageBuilding stoneStorage = new StorageBuilding("Entrepôt à caillou", 1, 5, false, stone, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(stoneStorage);

            // Iron
            StorageBuilding ironStorage = new StorageBuilding("Fer Ash'Fall", 1, 5, false, iron, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(ironStorage);

            // Oil
            StorageBuilding oilStorage = new StorageBuilding("Bidons", 1, 5, false, oil, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(oilStorage);

            // Electricity
            StorageBuilding electricityStorage = new StorageBuilding("Batteries", 1, 5, false, electricity, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(electricityStorage);

            // Food
            StorageBuilding foodStorage = new StorageBuilding("Frijdère", 1, 5, false, food, 1000, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(foodStorage);

            // Human
            StorageBuilding humanStorage = new StorageBuilding("maison", 1, 5, false, human, 10, 100)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allStorageBuildings.Add(humanStorage);
            allBuildings.AddRange(allStorageBuildings);
            #endregion

            #region MainBuilding
            MainBuilding mainBuilding = new MainBuilding("Forum", 1, 0, true, human, 10, 10)
            {
                Requirement = new List<LevelRequirement>()
                {
                    new LevelRequirement(2, null),
                    new LevelRequirement(3, null),
                    new LevelRequirement(4, null),
                    new LevelRequirement(5, null)
                }
            };
            allBuildings.Add(mainBuilding);
            #endregion
            #endregion

            return new Game(allBuildings, allCollectedResources);
        }

        public async Task<Tuple<List<RareResource>, List<Resource>>> GetStaticData()
        {
            List<Resource> allResources = new List<Resource>();
            List<RareResource> allRareResources = new List<RareResource>();

            if (db.RareResources.Count() > 0)
            {
                allRareResources = db.RareResources.ToList();
            }
            else
            {
                RareResource BoWood = new RareResource(ResourceType.RareWood);
                allRareResources.Add(BoWood);
                RareResource BoStone = new RareResource(ResourceType.RareStone);
                allRareResources.Add(BoStone);
                RareResource BoIron = new RareResource(ResourceType.RareIron);
                allRareResources.Add(BoIron);
                RareResource BoOil = new RareResource(ResourceType.RareOil);
                allRareResources.Add(BoOil);
                RareResource BoElek = new RareResource(ResourceType.RareElectricity);
                allRareResources.Add(BoElek);

                db.RareResources.AddRange(allRareResources);
                await db.SaveChangesAsync();
            }

            if (db.Resources.Count() > 0)
            {
                allResources = db.Resources.ToList();
            }
            else
            {
                Resource wood = new Resource(ResourceType.Wood, 5, allRareResources.Where(rr => rr.Name == ResourceType.RareWood).First());
                allResources.Add(wood);
                Resource stone = new Resource(ResourceType.Stone, 5, allRareResources.Where(rr => rr.Name == ResourceType.RareStone).First());
                allResources.Add(stone);
                Resource iron = new Resource(ResourceType.Iron, 5, allRareResources.Where(rr => rr.Name == ResourceType.RareIron).First());
                allResources.Add(iron);
                Resource oil = new Resource(ResourceType.Oil, 5, allRareResources.Where(rr => rr.Name == ResourceType.RareOil).First());
                allResources.Add(oil);
                Resource electricity = new Resource(ResourceType.Electricity, 5, allRareResources.Where(rr => rr.Name == ResourceType.RareElectricity).First());
                allResources.Add(electricity);
                Resource food = new Resource(ResourceType.Food, 0, null);
                allResources.Add(food);
                Resource human = new Resource(ResourceType.Human, 0, null);
                allResources.Add(human);

                db.Resources.AddRange(allResources);
                await db.SaveChangesAsync();
            }


            return new Tuple<List<RareResource>, List<Resource>>(allRareResources,allResources);
        }
    }
}