using Microsoft.AspNetCore.Mvc;
using CoreBase.Infra.Cross.DTO;
using CoreBase.Web.Controllers.Base;
using CoreBase.Domain.Interfaces.Services;
using CoreBase.Web.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace CoreBase.Web.Controllers
{
    public class CategoriesController : EntityBaseController<ICategoryService, CategoryDTO, CategoryViewModel>
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesController(ICategoryService categoryService, IProductService productService, IMemoryCache memoryCache, IServiceProvider services) : base(categoryService, memoryCache, services)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        // GET: product/1
        public IActionResult Index(int id)
        {
            var category = _categoryService.GetById(id);
            var mappedCategory = Mapper.Map<CategoryViewModel>(category);

            var products = _productService.GetActiveByCategory(id);
            var mappedProducts = Mapper.Map<List<ProductViewModel>>(products);
            mappedCategory.Products = mappedProducts;

            return View(mappedCategory);
        }
    }
}