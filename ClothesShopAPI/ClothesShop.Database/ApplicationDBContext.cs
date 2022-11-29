using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using ClothesShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClothesShoAPI.Database
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
              : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dress> Dress { get; set; }
        public DbSet<Shoe> Shoes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder
            //    .Entity<Order>()
            //    .HasOne(o => o.User)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(o => o.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<User>()
            //    .HasMany(u => u.Orders)
            //    .WithOne( o => o.User)
            //    .HasForeignKey(o => o.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Item>()
            //   .HasOne(i => i.Order)
            //   .WithMany(o => o.Items)
            //   .HasForeignKey(o => o.OrderId)
            //   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>().Ignore(o => o.TotalSum);

            base.OnModelCreating(builder);
        }
    }
}
