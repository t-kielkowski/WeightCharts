using MediatR;
using WeightCharts.Application.ApiAccess;
using WeightCharts.Application.Dto;

namespace WeightCharts.Application.Feature.Beehive
{
    public class GetSensorTempDataQuery : IRequest<ApiResponse<BeehiveTempDto>>
    {
        public WeightReadingsSearchParams SearchParams { get; }

        public GetSensorTempDataQuery(WeightReadingsSearchParams searchParams) => SearchParams = searchParams;
    }
}
