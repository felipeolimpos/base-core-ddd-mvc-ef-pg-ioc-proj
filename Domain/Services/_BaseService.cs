using CoreBase.Domain.Interfaces.Services;
using CoreBase.Infra.Cross.DTO;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace CoreBase.Domain.Services
{
    public abstract class BaseService<TEntity, TEntityDTO> : IDisposable, IBaseService<TEntityDTO>
        where TEntity : class
        where TEntityDTO : IEntityDTO
    {
        private readonly IBaseRepository<TEntity, TEntityDTO> _repository;

        public BaseService(IBaseRepository<TEntity, TEntityDTO> repository)
        {
            _repository = repository;
        }

        public void Add(TEntityDTO entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntityDTO GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(TEntityDTO entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
