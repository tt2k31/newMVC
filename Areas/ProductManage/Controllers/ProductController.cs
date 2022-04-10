using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M01.Services;
using Microsoft.AspNetCore.Mvc;

namespace M01.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        
        [TempData]
        public string StatusMessage {set; get;}

        public ProductController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        
        public IActionResult Index()
        {
            var product = _productService.OrderBy(p => p.Name).ToList();
            return View(product);
        }
    }
}