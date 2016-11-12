using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab4Class
{
    public class ProductManagement:DbContext
    {

       public DbSet<Customer> customerDB { get; set; }
       public DbSet<Product> productDB { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Property(customer => customer.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(customer => customer.address).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Customer>().Property(customer => customer.phonenumber).IsRequired().ToString().Equals(@"+407[0-9]+");
            modelBuilder.Entity<Customer>().Property(customer => customer.email).IsRequired().ToString().Equals(@"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$");
        }
    }
}
