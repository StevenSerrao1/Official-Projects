using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioSolution.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
