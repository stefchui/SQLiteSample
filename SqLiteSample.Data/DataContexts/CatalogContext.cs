using Microsoft.EntityFrameworkCore;
using SqLiteSample.Data.Models;

namespace SqLiteSample.Data.DataContexts
{
    public partial class CatalogContext : DbContext
    {
        public CatalogContext() { 
        }
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }
        public virtual DbSet<Product> Products
        {
            get;
            set;
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlite($"Data Source={_configuration["SqlLiteSettings:DbFilePath"]}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity => {
                entity.ToTable("Product");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnType("VARCHAR");
                entity.Property(e => e.Category).HasColumnType("VARCHAR");
                entity.Property(e => e.Description).HasColumnType("VARCHAR");
                entity.Property(e => e.Price).HasColumnType("DOUBLE");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}