using MediatR;
using System.Net;
using WeightCharts.Application.ApiAccess;

namespace WeightCharts.Application.Feature.GetBeehiveList
{
    public class GetBeehiveListQueryHandler : IRequestHandler<GetBeehiveListQuery, ApiResponse<List<string>>>
    {
        private readonly IApiClient _apiClient;

        public GetBeehiveListQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiResponse<List<string>>> Handle(GetBeehiveListQuery request, CancellationToken cancellationToken)
        {
            var response = await _apiClient.GetBeehiveList();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var beehiveList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(response.Content);
                return new ApiResponse<List<string>>(beehiveList);
            }

            return new ApiResponse<List<string>>(response.ErrorMessage);
        }
    }
}
