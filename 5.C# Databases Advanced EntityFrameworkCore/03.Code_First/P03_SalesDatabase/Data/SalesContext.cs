using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {

        public SalesContext()
        {

        }
        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=Sales;Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Email).IsUnicode(false);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description).HasDefaultValue("No description");


            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Date).HasDefaultValueSql("GETDATE()");
        }
    }
}
