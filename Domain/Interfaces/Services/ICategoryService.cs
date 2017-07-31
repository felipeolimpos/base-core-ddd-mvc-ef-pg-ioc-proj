using CoreBase.Infra.Cross.DTO;
using System.Collections.Generic;

namespace CoreBase.Domain.Interfaces.Services
{
    public interface ICategoryService : IBaseService<CategoryDTO>
    {
        IEnumerable<CategoryDTO> GetAllActive();
    }
}
