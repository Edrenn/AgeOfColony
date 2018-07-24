using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class CollectedResource : BaseObject
    {
        public Resource resource { get; set; }
        public int Quantity { get; set; }

    }
}