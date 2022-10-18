using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WeightCharts.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger _logger;      

        public HomeController(ILogger<HomeController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

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