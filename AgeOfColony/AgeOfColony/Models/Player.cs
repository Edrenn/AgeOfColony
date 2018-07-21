using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeOfColony.Models
{
    public class Player : BaseObject
    {
        public Game TheGame { get; set; }
        public String Username { get; set; }
    }
}