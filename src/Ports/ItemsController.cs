using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers
{
    
    public class ItemsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Content("Hello world");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Content("Posted!");
        }
    }
}