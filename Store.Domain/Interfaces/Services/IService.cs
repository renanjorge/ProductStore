namespace Store.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity GetById(int id);

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);
    }
}