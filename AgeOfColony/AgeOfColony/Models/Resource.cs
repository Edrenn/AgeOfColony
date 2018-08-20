using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class Resource : ViewableObject
    {
        /// <summary>
        /// Name of the Resource
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Percentage of luck of finding the RareVersion (5 = 5%)
        /// </summary>
        public int RarePercentage { get; set; }

        /// <summary>
        /// RareVersion of the current Resource
        /// </summary>
        public RareResource RareVersion { get; set; }

        public Resource(string name, int rarePercentage, RareResource rareVersion)
        {
            Name = name;
            RarePercentage = rarePercentage;
            RareVersion = rareVersion;
        }

        public Resource()
        {

        }
    }
}