using MediatR;
using WeightCharts.Application.Dto;

namespace WeightCharts.Application.Feature.Beehive
{
    public class GetSensorDataQuery : IRequest<ApiResponse<BeehiveDataDto>>
    {
        public int Id { get; set; }

        public GetSensorDataQuery(int id) => Id = id;
    }
}
