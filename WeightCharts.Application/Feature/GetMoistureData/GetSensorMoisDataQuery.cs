using MediatR;
using WeightCharts.Application.ApiAccess;
using WeightCharts.Application.Dto;

namespace WeightCharts.Application.Feature.GetMoistureData
{
    public class GetSensorMoisDataQuery : IRequest<ApiResponse<BeehiveMoisDto>>
    {
        public WeightReadingsSearchParams SearchParams { get; }

        public GetSensorMoisDataQuery(WeightReadingsSearchParams searchParams) => SearchParams = searchParams;
    }
}