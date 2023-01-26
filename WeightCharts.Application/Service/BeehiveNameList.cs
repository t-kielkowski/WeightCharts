using MediatR;
using WeightCharts.Application.Feature.GetBeehiveList;

namespace WeightCharts.Application.Service
{
    public class BeehiveNameList : IBeehiveNameList
    {
        private IMediator Mediator { get; }

        public BeehiveNameList(IMediator mediator) => Mediator = mediator;
        
        public async Task<IEnumerable<string>> GetBeehiveNameListAsync()
        {
            var command = new GetBeehiveListQuery();
            var result = await Mediator.Send(command).ConfigureAwait(false);
                        
            return result.Data?.Count > 0 ? result.Data : new List<string>();
        }
    }
}