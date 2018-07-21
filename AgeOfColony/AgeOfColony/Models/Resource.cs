using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class Resource : ViewableObject
    {
        public String Name { get; set; }
        public Resource RareVersion { get; set; }
        public int RarePercentage { get; set; }
    }
}