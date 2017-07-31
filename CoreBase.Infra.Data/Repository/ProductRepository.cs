using AutoMapper;
using CoreBase.Domain.Entities;
using CoreBase.Domain.Interfaces.Repositories;
using CoreBase.Infra.Cross.DTO;
using CoreBase.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace CoreBase.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product, ProductDTO>, IProductRepository
    {
        public ProductRepository(CoreContext context) : base(context)
        {
        }
        public IEnumerable<ProductDTO> GetActiveByCategory(int categoryId)
        {
            var activeCategories = All().Where(c => c.Active && c.CategoryId.Equals(categoryId)).ToList();
            return Mapper.Map<List<ProductDTO>>(activeCategories);
        }

        public IEnumerable<ProductDTO> GetAllActive()
        {
            var activeCategories = All().Where(c => c.Active).ToList();
            return Mapper.Map<List<ProductDTO>>(activeCategories);
        }
    }
}
