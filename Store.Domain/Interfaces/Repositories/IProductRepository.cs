using Store.Domain.Entities;
using System.Collections.Generic;

namespace Store.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product> 
    {
        public IList<Product> SelectWith(int skip, int take);
        public new Product Select(int id);
        public int Total();
    }
}