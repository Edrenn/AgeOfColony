using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public abstract class ViewableObject : BaseObject
    {
        public String ImgUrl { get; set; }
    }
}