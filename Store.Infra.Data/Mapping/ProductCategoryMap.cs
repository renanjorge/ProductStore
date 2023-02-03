using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.Infra.Data.Extensions.Seeds;
using System.Collections.Generic;

namespace Store.Infra.Data.Mapping
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("tblCategoriaProduto");

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

            builder.Seed();
        }
    }
}