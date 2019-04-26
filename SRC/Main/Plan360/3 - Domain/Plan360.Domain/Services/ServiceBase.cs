using System;
using System.Collections.Generic;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }


        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetTakeSkip(int take, int skip)
        {
            return _repository.GetTakeSkip(take, skip);
        }

        public IEnumerable<TEntity> GetSkipTake(int skip, int take)
        {
            return _repository.GetSkipTake(skip, take);

        }

        public int Count()
        {
            return _repository.Count();
        }

        public long LongCount()
        {
            return _repository.LongCount();
        }

        public IEnumerable<TEntity> DoSearch(string strSearch)
        {
            return _repository.DoSearch(strSearch);
        }
    }


}
