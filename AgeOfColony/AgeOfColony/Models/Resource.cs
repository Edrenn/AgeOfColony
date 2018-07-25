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
        public String Name { get; set; }
        public int RarePercentage { get; set; }

        [ForeignKey("RareVersion")]
        public int RareResourceId { get; set; }
        public RareResource RareVersion { get; set; }
    }
}