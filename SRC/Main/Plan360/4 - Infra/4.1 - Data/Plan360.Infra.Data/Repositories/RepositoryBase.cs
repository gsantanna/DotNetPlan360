using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Infra.Data.Context;

namespace Plan360.Infra.Data.Repositories
{

    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected Plan360DataContext Db = new Plan360DataContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetTakeSkip(int take, int skip)
        {
            return Db.Set<TEntity>().Take(take).Skip(skip);
        }

        public IEnumerable<TEntity> GetSkipTake(int skip, int take)
        {
            return Db.Set<TEntity>().Skip(skip).Take(take);
        }

        public IEnumerable<TEntity> DoSearch(string strSearch)
        {
            //TODO Use a String linq Query to get item by this name if property called name exists
            throw new NotImplementedException();
        }

        public int Count()
        {
            return Db.Set<TEntity>().Count();

        }

        public long LongCount()
        {
            return Db.Set<TEntity>().LongCount();
        }



        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();

        }
    }



}
