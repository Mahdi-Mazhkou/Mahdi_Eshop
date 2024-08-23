using Microsoft.EntityFrameworkCore;
using Shoping.DomainModel.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public  class ShopingMashtiMahdiContext:DbContext
    {
        public ShopingMashtiMahdiContext(DbContextOptions<ShopingMashtiMahdiContext> options):base(options)
        {
             
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductKeyword> ProductKeywords { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
            modelBuilder.ApplyConfiguration<Feature>(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
            modelBuilder.ApplyConfiguration<KeyWord>(new KeyWordConfiguration());
            modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
