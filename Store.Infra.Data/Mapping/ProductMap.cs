using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure (EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tblProduto");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasColumnName("Nome")
                   .HasColumnType("varchar(250)")
                   .HasMaxLength(250);

            builder.Property(c => c.Description)
                   .IsRequired()
                   .HasColumnName("Descricao")
                   .HasColumnType("varchar(250)")
                   .HasMaxLength(250);

            builder.Property(c => c.IsActive)
                   .IsRequired()
                   .HasColumnName("Ativo")
                   .HasColumnType("bit");

            builder.Property(c => c.IsPerishable)
                   .IsRequired()
                   .HasColumnName("Perecivel")
                   .HasColumnType("bit");

            builder.HasOne(c => c.ProductCategory)
                   .WithMany()
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}