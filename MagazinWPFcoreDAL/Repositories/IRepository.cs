using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinWPFcoreDAL.Repositories
{
    public interface IRepository<TEntity>:IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Delete(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Add(TEntity entity);
        void Save();
    }
}
