using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MagazinWPFcoreDAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal CarsDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            this.context = new CarsDbContext() ;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public TEntity Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (entityToDelete != null)
                Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (this.context.Entry(entityToDelete).State == EntityState.Detached)
                this.dbSet.Attach(entityToDelete);
            this.dbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this.context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
