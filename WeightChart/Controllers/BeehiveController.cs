using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace WeightCharts.Controllers
{
    public class BeehiveController : BaseController
    {
        protected BeehiveController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
