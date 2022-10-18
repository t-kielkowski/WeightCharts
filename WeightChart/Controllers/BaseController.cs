using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeightCharts.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator Mediator { get; }

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}