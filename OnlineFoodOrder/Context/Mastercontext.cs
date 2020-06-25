using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.Model;

namespace OnlineFoodOrder.Context
{
    public class Mastercontext: DbContext
    {
      
            public Mastercontext(DbContextOptions<Mastercontext> options) : base(options)
            { }

            public DbSet<Locations> locations { get; set; }
            public DbSet<Restaurants> restaurants { get; set; }

            public DbSet<Categories> categories { get; set; }

        public virtual DbSet<FoodList> FoodList { get; set; }

            public virtual DbSet<Payment> Payment { get; set; }
        public DbSet<Quantities> quantities { get; set; }

             public DbSet<Signup> signups { get; set; }

       public virtual DbSet<Orders> Orders { get; set; }

        public DbSet<FoodItems> FoodItems { get; set; }
        public DbSet<VFoodList> VFoodList { get; set; }

        public DbSet<VCategories> VCategories { get; set; }


    }

    }

