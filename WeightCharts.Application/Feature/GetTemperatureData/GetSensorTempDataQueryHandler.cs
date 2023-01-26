using MediatR;
using System.Net;
using WeightCharts.Application.ApiAccess;
using WeightCharts.Application.Dto;

namespace WeightCharts.Application.Feature.Beehive
{
    public class GetSensorTempDataQueryHandler : IRequestHandler<GetSensorTempDataQuery, ApiResponse<BeehiveTempDto>>
    {
        private readonly IApiClient _apiClient;

        public GetSensorTempDataQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiResponse<BeehiveTempDto>> Handle(GetSensorTempDataQuery request, CancellationToken cancellationToken)
        {
            var response = await _apiClient.GetTemperatureData(request.SearchParams);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var beeHiveTemp = Newtonsoft.Json.JsonConvert.DeserializeObject<BeehiveTempDto>(response.Content);
                return new ApiResponse<BeehiveTempDto>(beeHiveTemp);
            }

            return new ApiResponse<BeehiveTempDto>(!string.IsNullOrEmpty(response.ErrorMessage) ? response.ErrorMessage : _apiClient.DefaultErrorMessage);
        }
    }
}
