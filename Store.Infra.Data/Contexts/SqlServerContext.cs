using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infra.Data.Mapping;

namespace Store.Infra.Data.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductCategoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}