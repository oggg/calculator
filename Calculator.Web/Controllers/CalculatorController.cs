using Calculator.Services.Interfaces;
using Calculator.Types;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICalculateCacheService _calculateCacheService;
        public CalculatorController(IServiceProvider serviceProvider, ICalculateCacheService calculateCacheService)
        {
            _serviceProvider = serviceProvider;
            _calculateCacheService = calculateCacheService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Operations = GetOperations();
            return View();
        }

        [HttpPost]
        public ActionResult Index(CalculateModel model)
        {
            ViewBag.Operations = GetOperations();
            if (model.SecondNumber == 0 && model.Operation == OperationEnum.Division)
            {
                ModelState.AddModelError(nameof(CalculateModel.Result), "Division by zero");
            }

            if (!ModelState.IsValid)
                return View(model);

            var calculatorOperationService = _serviceProvider
                .GetServices<ICalculateService>()
                .Single(x => x.Operation == model.Operation);

            model.Result = calculatorOperationService.Calculate(model.FirstNumber, model.SecondNumber);
            _calculateCacheService.SetCacheValue(GetClientIPAddress(Request.HttpContext), model);

            return View(model);
        }

        [HttpGet]
        public IActionResult GetHistory()
        {
            var cachedCalculations = _calculateCacheService
                .GetCacheValue(GetClientIPAddress(Request.HttpContext));
            return Json(cachedCalculations);
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        private IEnumerable<OperationEnum> GetOperations()
        {
            return Enum.GetValues(typeof(OperationEnum)).Cast<OperationEnum>();
        }

        public static string GetClientIPAddress(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Headers["X-Forwarded-For"]))
            {
                return context.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return context.Request.HttpContext.Features.Get<IHttpConnectionFeature>().RemoteIpAddress.ToString();
            }
        }
    }
}
