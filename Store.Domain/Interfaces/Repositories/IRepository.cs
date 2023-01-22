using Store.Domain.Entities;

namespace Store.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Select(int id);

        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);

        void Dispose();
    }
}