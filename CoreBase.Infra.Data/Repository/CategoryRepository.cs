using AutoMapper;
using CoreBase.Domain.Entities;
using CoreBase.Domain.Interfaces.Repositories;
using CoreBase.Infra.Cross.DTO;
using CoreBase.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace CoreBase.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category, CategoryDTO>, ICategoryRepository
    {
        public CategoryRepository(CoreContext context) : base(context)
        {
        }
        public IEnumerable<CategoryDTO> GetAllActive()
        {
            var activeCategories = All().Where(c => c.Active).ToList();
            return Mapper.Map<List<CategoryDTO>>(activeCategories);
        }
    }
}
