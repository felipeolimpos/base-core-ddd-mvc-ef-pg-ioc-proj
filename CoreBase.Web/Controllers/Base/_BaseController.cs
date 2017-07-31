using AutoMapper;
using CoreBase.Domain.Interfaces.Services;
using CoreBase.Web.Utils;
using CoreBase.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CoreBase.Web.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        protected readonly IServiceProvider _services;

        public BaseController(IMemoryCache memoryCache, IServiceProvider services)
        {
            _memoryCache = memoryCache;
            _services = services;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var categories = HttpContext.Session.GetObjectFromJson<List<CategoryViewModel>>("Categories");

            if (categories == null)
            {
                HttpContext.Session.SetObjectAsJson("Categories", GetCachedCategories());
            }

            var cart = GetCart();
            ViewBag.CartQuantity = cart.Quantity;
        }

        protected CartViewModel GetCart()
        {
            var cart = new CartViewModel();
            var cookie = Request.Cookies["Cart"];

            if (cookie != null)
            {
                cart = (CartViewModel)JsonConvert.DeserializeObject(cookie, typeof(CartViewModel));
            }
            else
            {
                cart.Items = new List<CartItemViewModel>();
                SetCart(cart);
            }

            return cart;
        }

        protected void SetCart(CartViewModel cart)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(2);
            var cartValue = JsonConvert.SerializeObject(cart);
            Response.Cookies.Append("Cart", cartValue, cookieOptions);
        }

        protected IList<CategoryViewModel> GetCachedCategories()
        {
            List<CategoryViewModel> categories;
            bool exists = _memoryCache.TryGetValue("Categories", out categories);
            if (!exists)
            {
                categories = UpdateCategoriesCache();
            }
            return categories;
        }

        protected List<CategoryViewModel> UpdateCategoriesCache()
        {
            var categoryService = (ICategoryService)_services.GetService(typeof(ICategoryService));

            var categoriesDTO = categoryService.GetAllActive();
            var categories = Mapper.Map<List<CategoryViewModel>>(categoriesDTO);

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));

            _memoryCache.Set("Categories", categories, cacheEntryOptions);

            UpdateCategoriesSession();

            return categories;
        }

        protected void UpdateCategoriesSession()
        {
            var categories = GetCachedCategories();

            HttpContext.Session.SetObjectAsJson("Categories", GetCachedCategories());
        }
    }
}