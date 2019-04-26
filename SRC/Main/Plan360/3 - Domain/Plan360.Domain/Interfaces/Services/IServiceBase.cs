using System.Collections.Generic;

namespace Plan360.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        IEnumerable<TEntity> GetTakeSkip(int take, int skip);
        IEnumerable<TEntity> GetSkipTake(int skip, int take);
        int Count();
        long LongCount();
        IEnumerable<TEntity> DoSearch(string strSearch);

    }



}
