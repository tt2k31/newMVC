using M01.Services;
using Microsoft.AspNetCore.Mvc;

namespace M01.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        
        [TempData]
        public string StatusMessage {set; get;}
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index()
        {
            // this.HttpContext
            //this.HttpRequest
            //this.HttpRespone
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag

            // _logger.Log(LogLevel.Warning, "cảnh báo");
            _logger.LogWarning("Cảnh báo");
            //serilog


            _logger.LogInformation("live action");

            return "toi là first index";
        }

        public void Nothing()
        {
            _logger.LogInformation("mong gi");
            Response.Headers.Add("Hi", "xin chao");
        }

        public object Anything()
        {
            return DateTime.Now;
        }

        public IActionResult Readme()
        {
            var content = @"
                Hello 
                Chao xin
                        
            ";
            return this.Content(content, "text/plan");
        }

        public IActionResult pic()
        {
            //chưa hiêy
            return this.Content("meo", "text/html");
        }

        public IActionResult Jsonfile()
        {
            return Json(
                new
                {
                    name = "Iphone",
                    gia = 1000
                }
            );
        }

        public IActionResult Privacy()
        {
            var url = this.Url.Action("Privacy", "Home");
            return LocalRedirect(url); // trong url không có phần host, chuyển đến các file trong nội bộ
        }
        public IActionResult Google()
        {
            var url = "https://google.com";
            return Redirect(url); // 
        }




        //ViewResult
        public IActionResult helloview(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = "khach";
            }

            // return View("/MyView/Xinchao1.cshtml", username);
            //TH1: view(template) : đường dẫn của template
            // Th2: view(template, model): truyền dữ liệu sang page

            //Th3:View("Hello1", username); ~~ tìm đến View/First/Hello1
            // return View("Hello1", username);

            //TH: mở view trùng với action
            return View((object)username);
        }

        [AcceptVerbs("POST", "GET")]
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                TempData["StatusMessage"] = "ko có SP";
                return Redirect(Url.Action("Index", "Home"));
            }
            //truyền qua model
            // return View(product);

            //truyền qua viewdata
            // ViewData["product"] = product;
            // return View("ViewProduct2"); 

            //truyen qua viewbag
            this.ViewBag.product = product;
            return View("ViewProduct3"); 


        }
    }
}