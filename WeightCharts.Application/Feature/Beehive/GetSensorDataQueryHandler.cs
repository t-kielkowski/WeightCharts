using MediatR;

namespace WeightCharts.Application.Feature.Beehive
{
    public class GetSensorDataQueryHandler : IRequestHandler<GetSensorDataQuery, Unit>
    {
        public GetSensorDataQueryHandler()
        {
        }

        public Task<Unit> Handle(GetSensorDataQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
