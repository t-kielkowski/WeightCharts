using Microsoft.AspNetCore.Mvc;

namespace WeightCharts.Controllers
{
    public class BeehiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
