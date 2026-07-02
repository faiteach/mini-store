using Microsoft.EntityFrameworkCore;
using mini_store.Models;

namespace mini_store.Data
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions< AppDbContext> options)
        :base(options)
        {
            
        }
        public DbSet<Product> products{get;set;}
        public DbSet<Items> items {get;set;}
        public DbSet<Costumers> costumers {get;set;}
        public DbSet<Details> details {get;set;}
        public DbSet<Categories> categories {get;set;}
        public DbSet<Image> images {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.Price)
                .HasPrecision(18, 2);
        }

    } 
}
