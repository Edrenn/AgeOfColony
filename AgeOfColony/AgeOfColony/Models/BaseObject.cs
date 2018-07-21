using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public abstract class BaseObject
    {
        [Key]
        public int PrimaryKey { get; set; }
    }
}