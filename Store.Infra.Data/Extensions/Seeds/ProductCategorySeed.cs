using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Extensions.Seeds
{
    public static partial class EntityTypeBuilderExtensionSeed
    {
        public static void Seed(this EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(new ProductCategory
            {
                Id = 1,
                Name = "Eletrônico",
                Description = "Eletrodomésticos",
                IsActive = true
            },
            new ProductCategory
            {
                Id = 2,
                Name = "Informática",
                Description = "Produtos para Informática",
                IsActive = true
            },
            new ProductCategory
            {
                Id = 3,
                Name = "Celulares",
                Description = "Aparelhos e acessórios",
                IsActive = true
            },
            new ProductCategory
            {
                Id = 4,
                Name = "Moda",
                Description = "Artigos para vestuário em geral",
                IsActive = true
            },
            new ProductCategory
            {
                Id = 5,
                Name = "Livros",
                Description = "Livros",
                IsActive = true
            });
        }
    }
}