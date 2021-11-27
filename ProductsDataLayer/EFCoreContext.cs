using Microsoft.EntityFrameworkCore;
using MyProductsService.Controllers;
using ProductsCore.Models;
using System;

namespace ProductsDataLayer
{
    public class EFCoreContext:DbContext
    {
        public DbSet<CategoryDb> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AccountInfo> Users { get; set; }
        public EFCoreContext(DbContextOptions<EFCoreContext>options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
            });
         
            modelBuilder.Entity<AccountInfo>().
                OwnsOne(accountInfo=> accountInfo.LoginInfo,
                loginInfo =>
                {
                    loginInfo.Property(i => i.Login).HasColumnName("Login");
                    loginInfo.Property(i => i.Password).HasColumnName("Password");
                });
          
        }
    }
}
