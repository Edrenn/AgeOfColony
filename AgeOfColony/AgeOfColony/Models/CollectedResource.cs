using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class CollectedResource : BaseObject
    {
        public Resource Resource { get; set; }
        public int Quantity { get; set; }
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