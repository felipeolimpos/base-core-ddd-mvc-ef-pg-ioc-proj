using CoreBase.Domain.Entities;
using CoreBase.Domain.Interfaces.Repositories;
using CoreBase.Domain.Interfaces.Services;
using CoreBase.Infra.Cross.DTO;
using System.Collections.Generic;

namespace CoreBase.Domain.Services
{
    public class CategoryService : BaseService<Category, CategoryDTO>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDTO> GetAllActive()
        {
            return _categoryRepository.GetAllActive();
        }
    }
}
