using Store.Domain.Entities;
using System.Collections.Generic;

namespace Store.Domain.Interfaces.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory> 
    {
        public IList<ProductCategory> Select();
    }
}