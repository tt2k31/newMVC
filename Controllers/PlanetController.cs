using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M01.Services;
using Microsoft.AspNetCore.Mvc;

namespace M01.Controllers
{
    
    public class PlanetController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly PlanetService _planetService;
        
        [TempData]
        public string StatusMessage {set; get;}

        //Lấy từ URL gán vào Name
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name {set; get;}
        
        public PlanetController(ILogger<FirstController> logger,PlanetService planetService)
        {
            _logger = logger;
            _planetService = planetService;
        }
        
        [Route("danhsach")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("sao/[action]", Order = 1, Name = "mercury")] 
        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Uranus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Neptune()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}