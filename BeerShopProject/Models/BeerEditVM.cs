using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerShopProject.Models
{
    public class BeerEditVM
    {
        public int? id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool HasTried { get; set; }
    }
}