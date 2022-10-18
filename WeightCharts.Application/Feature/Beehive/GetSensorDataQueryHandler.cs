using MediatR;
using RestSharp;
using WeightCharts.Application.Dto;

namespace WeightCharts.Application.Feature.Beehive
{
    public class GetSensorDataQueryHandler : IRequestHandler<GetSensorDataQuery, ApiResponse<BeehiveDataDto>>
    {
        public async Task<ApiResponse<BeehiveDataDto>> Handle(GetSensorDataQuery request, CancellationToken cancellationToken)
        {
            var client = new RestClient("https://localhost:7064");
            var getRequest = new RestRequest("/api/Beehive/get", Method.Get);
            var  response = await client.ExecuteGetAsync(getRequest);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var beeHiveData = Newtonsoft.Json.JsonConvert.DeserializeObject<BeehiveDataDto>(response.Content);
                return new ApiResponse<BeehiveDataDto>(beeHiveData);                    
            }

            return new ApiResponse<BeehiveDataDto>(response.ErrorMessage);
        }
    }
}
