using Store.Domain.Entities;
using Store.Domain.Interfaces.Repositories;
using Store.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Store.Service.Services
{
    public class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryService(IProductCategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IList<ProductCategory> GetAll() => _repository.Select();
    }
}