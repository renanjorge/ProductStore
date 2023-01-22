using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces.Repositories;
using Store.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Store.Infra.Data.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(SqlServerContext context) : base(context) { }

        public IList<ProductCategory> Select()
        {
            return DbSet.AsTracking().Where(c => c.IsActive).ToList();
        }
    }
}