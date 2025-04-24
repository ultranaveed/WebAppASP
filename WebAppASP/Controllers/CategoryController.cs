using Microsoft.AspNetCore.Mvc;

namespace WebAppASP.Controllers{
    public class CategoryController : Controller{
        public IActionResult Index(){
            return View();
        }
    }
}