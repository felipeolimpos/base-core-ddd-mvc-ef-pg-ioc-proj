using CoreBase.Web.Controllers.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;

namespace CoreBase.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILoggerFactory _loggerFactory;
        public HomeController(IMemoryCache memoryCache, IServiceProvider services, ILoggerFactory loggerFactory) : base(memoryCache, services)
        {
            _loggerFactory = loggerFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error(int code)
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exception != null)
            {
                // LOG Error
                var log = _loggerFactory.CreateLogger<BaseController>();
                log.LogError(string.Format("{0} - STACK TRACE :", exception.Error.Message, exception.Error.StackTrace));
            }

            ViewBag.Error = true;
            return View("Index");
        }
    }
}
