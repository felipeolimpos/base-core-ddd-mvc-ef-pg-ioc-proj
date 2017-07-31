using CoreBase.Infra.Cross.DTO;
using System.Collections.Generic;

namespace CoreBase.Domain.Interfaces.Services
{
    public interface IProductService : IBaseService<ProductDTO>
    {
        IEnumerable<ProductDTO> GetAllActive();
        IEnumerable<ProductDTO> GetActiveByCategory(int categoryId);
    }
}
