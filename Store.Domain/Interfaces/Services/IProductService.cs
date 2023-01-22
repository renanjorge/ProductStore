using Store.Domain.Entities;
using System.Collections.Generic;

namespace Store.Domain.Interfaces.Services
{
    public interface IProductService : IService<Product>
    {
        public (IList<Product> products, int total) GetPagedList(int pageNumber, int pageSize);
        public new Product GetById(int id);
    }
}