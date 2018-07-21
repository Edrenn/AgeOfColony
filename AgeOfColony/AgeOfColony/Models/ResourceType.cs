using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class ResourceType
    {
        // Basic Resource
        public const String Wood = "Bois";
        public const String Stone = "Caillou";
        public const String Food = "Nourriture";
        public const String Iron = "Fer";
        public const String Oil = "Pétrole";
        public const String Electricity = "Electricité";
        public const String Human = "Humain";

        // Rare Resource
        public const String RareWood = "LeBoBois";
        public const String RareStone = "LaBoPierre";
        public const String RareIron = "LeBoFer";
        public const String RareOil = "LeBoPétrole";
        public const String RareElectricity = "LeBoElectricité";
    }
}