using Microsoft.AspNetCore.Mvc;

namespace COMP1004_Project.Controllers
{
    public class DND : Controller
    {
        [Route("Home/{name?}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
