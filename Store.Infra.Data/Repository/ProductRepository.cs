using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces.Repositories;
using Store.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Store.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SqlServerContext context) : base(context) { }

        public IList<Product> SelectWith(int skip, int take)
        {
            return DbSet.Include(c => c.ProductCategory)
                        .AsNoTracking()
                        .OrderByDescending(c => c.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToList();
        }

        public override Product Select(int id)
        {
            return DbSet.Include(c => c.ProductCategory)
                        .Where(c => c.Id == id)
                        .SingleOrDefault();
        }

        public int Total()
        {
            return DbSet.AsTracking().Count();
        }
    }
}