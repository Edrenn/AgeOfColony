﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AgeOfColony.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Notez que authenticationType doit correspondre à l'instance définie dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Ajouter des revendications d’utilisateur personnalisées ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
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