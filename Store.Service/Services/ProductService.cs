using Store.Domain.Entities;
using Store.Domain.Interfaces.Repositories;
using Store.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Store.Service.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public (IList<Product> products, int total) GetPagedList(int pageNumber, int pageSize)
        {
            var products = _repository.SelectWith(pageNumber, pageSize);
            var total = _repository.Total();

            return (products, total);
        }

        public override Product GetById(int id) => _repository.Select(id);
    }
}
