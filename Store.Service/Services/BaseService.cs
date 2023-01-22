
using Store.Domain.Interfaces.Repositories;
using Store.Domain.Interfaces.Services;

namespace Store.Service.Services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository) 
        {
            _repository = repository;
        }

        public virtual TEntity GetById(int id) => _repository.Select(id);

        public void Add(TEntity obj) => _repository.Insert(obj);

        public void Update(TEntity obj) => _repository.Update(obj);

        public void Delete(int id) => _repository.Delete(id);
    }
}