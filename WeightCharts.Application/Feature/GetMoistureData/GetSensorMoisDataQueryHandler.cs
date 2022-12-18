using MediatR;
using System.Net;
using WeightCharts.Application.ApiAccess;
using WeightCharts.Application.Dto;

namespace WeightCharts.Application.Feature.GetMoistureData
{
    public class GetSensorMoisDataQueryHandler : IRequestHandler<GetSensorMoisDataQuery, ApiResponse<BeehiveMoisDto>>
    {
        private readonly IApiClient _apiClient;

        public GetSensorMoisDataQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiResponse<BeehiveMoisDto>> Handle(GetSensorMoisDataQuery request, CancellationToken cancellationToken)
        {
            var response = await _apiClient.GetMoistureData(request.SearchParams);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var beeHiveMois = Newtonsoft.Json.JsonConvert.DeserializeObject<BeehiveMoisDto>(response.Content);
                return new ApiResponse<BeehiveMoisDto>(beeHiveMois);
            }

            return new ApiResponse<BeehiveMoisDto>(response.ErrorMessage);
        }
    }
}
