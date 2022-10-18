using MediatR;

namespace WeightCharts.Application.Feature.Beehive
{
    public class GetSensorDataQuery : IRequest<Unit>
    {
        public int Id { get; set; }

        public GetSensorDataQuery(int id) => Id = id;
    }
}
