using MediatR;
using WeightCharts.Application.ApiAccess;
using WeightCharts.Application.Dto;

namespace WeightCharts.Application.Feature.GetWeightData
{
    public class GetSensorWeightDataQuery : IRequest<ApiResponse<BeehiveWeightDto>>
    {
        public WeightReadingsSearchParams SearchParams { get; }

        public GetSensorWeightDataQuery(WeightReadingsSearchParams searchParams) => SearchParams = searchParams;
    }
}
