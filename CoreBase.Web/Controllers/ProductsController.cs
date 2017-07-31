using AutoMapper;
using CoreBase.Domain.Interfaces.Services;
using CoreBase.Infra.Cross.DTO;
using CoreBase.Web.Controllers.Base;
using CoreBase.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace CoreBase.Web.Controllers
{
    public class ProductsController : EntityBaseController<IProductService, ProductDTO, ProductViewModel>
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, IMemoryCache memoryCache, IServiceProvider services) : base(productService, memoryCache, services)
        {
            _productService = productService;
        }

        // GET: product/1
        public IActionResult Index(int id)
        {
            var product = _productService.GetById(id);
            var mappedProduct = Mapper.Map<ProductViewModel>(product);

            return View(mappedProduct);
        }
    }
}