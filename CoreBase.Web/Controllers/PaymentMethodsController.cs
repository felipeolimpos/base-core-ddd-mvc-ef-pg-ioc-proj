using CoreBase.Domain.Interfaces.Services;
using CoreBase.Infra.Cross.DTO;
using CoreBase.Web.Controllers.Base;
using CoreBase.Web.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace CoreBase.Web.Controllers
{
    public class PaymentMethodsController : EntityBaseController<IPaymentMethodService, PaymentMethodDTO, PaymentMethodViewModel>
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodsController(IPaymentMethodService paymentMethodService, IMemoryCache memoryCache, IServiceProvider services) : base(paymentMethodService, memoryCache, services)
        {
            _paymentMethodService = paymentMethodService;
        }
    }
}