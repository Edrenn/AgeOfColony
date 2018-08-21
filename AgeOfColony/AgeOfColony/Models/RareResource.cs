using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class RareResource : ViewableObject
    {
        public String Name { get; set; }

        public RareResource(string name)
        {
            Name = name;
        }

        public RareResource()
        {

        }
    }
}