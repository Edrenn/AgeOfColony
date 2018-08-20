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

        public override string ToString()
        {
            return Quantity + "," + Resource.Name;
        }

    }
}