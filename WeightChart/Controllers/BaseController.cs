using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeightCharts.Application.ApiAccess;

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

        protected WeightReadingsSearchParams CreateSearchParams(string id, DateTime? dateFrom, DateTime? dateTo) => new()
        {
            WeightId = id,
            DateFrom = dateFrom,
            DateTo = dateTo
        };
    }
}