using Store.Domain.Entities;
using System.Collections.Generic;

namespace Store.Domain.Interfaces.Services
{
    public interface IProductCategoryService : IService<ProductCategory>
    {
        public IList<ProductCategory> GetAll();
    }
}