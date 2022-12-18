using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeightCharts.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator Mediator { get; }
        protected ILogger Logger { get; }

        protected BaseController(IMediator mediator, ILogger logger)
        {
            Mediator = mediator;
            Logger = logger;
        }
    }
}