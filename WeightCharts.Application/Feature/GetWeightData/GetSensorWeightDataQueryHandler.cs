using MediatR;
using System.Net;
using WeightCharts.Application.ApiAccess;
using WeightCharts.Application.Dto;

namespace WeightCharts.Application.Feature.GetWeightData
{
    public class GetSensorWeightDataQueryHandler : IRequestHandler<GetSensorWeightDataQuery, ApiResponse<BeehiveWeightDto>>
    {
        private readonly IApiClient _apiClient;

        public GetSensorWeightDataQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiResponse<BeehiveWeightDto>> Handle(GetSensorWeightDataQuery request, CancellationToken cancellationToken)
        {
            var response = await _apiClient.GetWeightData(request.SearchParams);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var beeHiveWeight = Newtonsoft.Json.JsonConvert.DeserializeObject<BeehiveWeightDto>(response.Content);
                return new ApiResponse<BeehiveWeightDto>(beeHiveWeight);
            }

            return new ApiResponse<BeehiveWeightDto>(!string.IsNullOrEmpty(response.ErrorMessage) ? response.ErrorMessage : _apiClient.DefaultErrorMessage);
        }
    }
}
