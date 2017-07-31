using CoreBase.Domain.Entities;
using CoreBase.Domain.Interfaces.Repositories;
using CoreBase.Domain.Interfaces.Services;
using CoreBase.Infra.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBase.Domain.Services
{
    public class ProductService : BaseService<Product, ProductDTO>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetActiveByCategory(int categoryId)
        {
            return _productRepository.GetActiveByCategory(categoryId);
        }

        public IEnumerable<ProductDTO> GetAllActive()
        {
            return _productRepository.GetAllActive();
        }
    }
}
