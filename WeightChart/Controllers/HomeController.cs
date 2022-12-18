using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WeightCharts.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, IMediator mediator) : base(mediator, logger)
        {}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}