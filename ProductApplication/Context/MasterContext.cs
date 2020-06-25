using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApplication.Models;
using ProductApplication.Model;

namespace ProductApplication.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }
        public DbSet<Customers> customers { get; set; }

        public DbSet<CustomerIdentification> customerIdentifications { get; set; }

        public virtual DbSet<Products> Products { get; set; }

        public DbSet<ProductApplication.Model.Products> Products_1 { get; set; }


    }
}
