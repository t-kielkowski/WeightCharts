using MediatR;
using WeightCharts.Application.ApiAccess;

namespace WeightCharts.Application.Feature.GetBeehiveList
{
    public class GetBeehiveListQuery : IRequest<ApiResponse<List<string>>>
    {
    }
}