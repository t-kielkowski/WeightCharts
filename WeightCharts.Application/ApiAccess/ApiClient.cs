using Microsoft.Extensions.Options;
using RestSharp;

namespace WeightCharts.Application.ApiAccess
{
    public class ApiClient : IApiClient
    {
        private readonly ApiConfiguration _apiConfiguration; 
        private RestClient _client;

        public ApiClient(IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            _client = new RestClient(apiConfiguration.Value.BaseApiUrl);
        }

        public async Task<RestResponse> GetBeehiveList()
        {            
            var getRequest = new RestRequest(_apiConfiguration.BeehiveListUrl, Method.Get);
            var response = await _client.ExecuteGetAsync(getRequest);

            return response;
        }

        public async Task<RestResponse> GetTemperatureData(IWeightReadingsSearchParams searchParams)
        {
            var getRequest = new RestRequest(_apiConfiguration.TemperatureUrl, Method.Get);
            getRequest = AddParameters(getRequest, searchParams);
            var response = await _client.ExecuteGetAsync(getRequest);

            return response;
        }

        public async Task<RestResponse> GetMoistureData(IWeightReadingsSearchParams searchParams)
        {
            var getRequest = new RestRequest(_apiConfiguration.MoistureUrl, Method.Get);
            getRequest = AddParameters(getRequest, searchParams);
            var response = await _client.ExecuteGetAsync(getRequest);

            return response;
        }

        public async Task<RestResponse> GetWeightData(IWeightReadingsSearchParams searchParams)
        {
            var getRequest = new RestRequest(_apiConfiguration.WeightUrl, Method.Get);
            getRequest = AddParameters(getRequest, searchParams);
            var response = await _client.ExecuteGetAsync(getRequest);

            return response;
        }

        private RestRequest AddParameters(RestRequest request, IWeightReadingsSearchParams searchParams)
        {
            request.AddParameter("id", searchParams.WeightId);
            request.AddParameter("dateFrom", searchParams.DateFrom?.ToString());
            request.AddParameter("dateTo", searchParams.DateTo?.ToString());

            return request;
        }
    }
}
