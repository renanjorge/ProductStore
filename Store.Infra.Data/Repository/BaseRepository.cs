using Microsoft.EntityFrameworkCore;
using Store.Domain.Interfaces.Repositories;
using Store.Infra.Data.Contexts;

namespace Store.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SqlServerContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(SqlServerContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Select(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
            Db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
