using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BeerShopProject.Models
{
    public class BeerDBContext : DbContext
    {
        public DbSet<BeerEditVM> BeerDB { get; set; }
    }
}