using System.Collections.Generic;

namespace Plan360.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);
        
        IEnumerable<TEntity> GetAll();
        
        void Update(TEntity obj);
        
        void Remove(TEntity obj);

        void Dispose();

        IEnumerable<TEntity> GetTakeSkip(int take, int skip);

        IEnumerable<TEntity> GetSkipTake(int skip, int take);

        IEnumerable<TEntity> DoSearch(string strSearch);


        int Count();

        long LongCount();


    }
}
