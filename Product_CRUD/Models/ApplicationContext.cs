using Microsoft.EntityFrameworkCore;
using Product_CRUD.Models.Configuration;
using Product_CRUD.Models.Entities;

namespace Product_CRUD.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Tax)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>().Property(p => p.NetPrice).HasPrecision(10, 2);
            modelBuilder.Entity<Tax>().Property(t => t.Value).HasPrecision(10, 2);

            modelBuilder.ApplyConfiguration(new TaxConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
