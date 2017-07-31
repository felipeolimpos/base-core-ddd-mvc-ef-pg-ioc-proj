using CoreBase.Domain.Entities;
using CoreBase.Infra.Cross.DTO;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace CoreBase.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product, ProductDTO>
    {
        IEnumerable<ProductDTO> GetAllActive();
        IEnumerable<ProductDTO> GetActiveByCategory(int categoryId);
    }
}
