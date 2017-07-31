using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoreBase.Web.ViewModels;
using CoreBase.Web.Controllers.Base;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using CoreBase.Domain.Interfaces.Services;
using AutoMapper;

namespace CoreBase.Web.Controllers
{
    public class CartController : BaseController
    {
        public CartController(IMemoryCache memoryCache, IServiceProvider services) : base(memoryCache, services)
        {

        }
        // GET: Cart
        public IActionResult Index()
        {
            var cartViewModel = GetCart();

            return View(cartViewModel);
        }

        // POST: Cart/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int id, int quantity = 1)
        {
            if (ModelState.IsValid)
            {
                var cart = GetCart();

                var productAlreadyOnCart = cart.Items.Any(i => i.Product.ID.Equals(id));

                if (productAlreadyOnCart)
                {
                    var cartItem = cart.Items.First(i => i.Product.ID.Equals(id));
                    cartItem.Quantity += quantity;
                }
                else
                {
                    AddNewItemToCart(id, cart, quantity);
                }

                SetCart(cart);
            }

            return RedirectToAction("Index");
        }


        // POST: Cart/Remove
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var cart = GetCart();

            var productOnCart = cart.Items.Any(i => i.Product.ID.Equals(id));

            if (productOnCart)
            {
                var cartItem = cart.Items.First(i => i.Product.ID.Equals(id));
                cart.Items.Remove(cartItem);
                SetCart(cart);
            }

            return PartialView("Cart", cart);
        }

        // POST: Cart/Clear
        [HttpPost]
        public IActionResult Clear()
        {
            CartViewModel cart = ClearCartCookie();
            return PartialView("Cart", cart);
        }

        // GET: Cart/Checkout
        public IActionResult Checkout()
        {
            var paymentMethodService = (IPaymentMethodService)_services.GetService(typeof(IPaymentMethodService));
            var paymentMethods = paymentMethodService.GetAllActive();
            var mappedPaymentMethods = Mapper.Map<List<PaymentMethodViewModel>>(paymentMethods);

            var checkoutViewModel = new CheckoutViewModel
            {
                Cart = GetCart(),
                PaymentMethods = mappedPaymentMethods
            };

            return View(checkoutViewModel);
        }

        // GET: Cart/Checkout
        public IActionResult Submitted()
        {
            ClearCartCookie();
            ViewBag.CartQuantity = 0;

            return View();
        }

        private void AddNewItemToCart(int id, CartViewModel cart, int quantity)
        {
            var productService = (IProductService)_services.GetService(typeof(IProductService));
            var product = productService.GetById(id);
            var mappedProduct = Mapper.Map<ProductViewModel>(product);
            var cartItem = new CartItemViewModel
            {
                Product = mappedProduct,
                Quantity = quantity,
            };
            cart.Items.Add(cartItem);
        }

        private CartViewModel ClearCartCookie()
        {
            var cart = new CartViewModel();
            cart.Items = new List<CartItemViewModel>();
            SetCart(cart);
            return cart;
        }
    }
}