using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class CollectedResource : BaseObject
    {
        public Resource Resource { get; set; }
        [Range(0, 3000)]
        public int Quantity { get; set; }
        [Range(0, 3000)]
        public int? RareQuantity { get; set; }

        public CollectedResource(Resource resource, int quantity, int rareQuantity = 0)
        {
            Resource = resource;
            Quantity = quantity;
            RareQuantity = rareQuantity;
        }

        public CollectedResource()
        {

        }

        public string ResourceToString()
        {
            return Quantity + "," + Resource.Name;
        }

        public string RareResourceToString()
        {
            return Quantity + "," + Resource.RareVersion.Name;
        }
    }
}