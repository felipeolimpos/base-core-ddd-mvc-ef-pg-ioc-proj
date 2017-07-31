using CoreBase.Infra.Cross.DTO;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TEntityDTO> : IDisposable
        where TEntity : class
        where TEntityDTO : IEntityDTO
    {
        void Add(TEntityDTO entity);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO entity);
        void Remove(int id);
    }
}
