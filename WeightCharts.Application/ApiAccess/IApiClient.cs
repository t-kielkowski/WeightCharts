using RestSharp;

namespace WeightCharts.Application.ApiAccess
{
    public interface IApiClient
    {
        Task<RestResponse> GetBeehiveList();
        Task<RestResponse> GetTemperatureData(IWeightReadingsSearchParams searchParams);
        Task<RestResponse> GetMoistureData(IWeightReadingsSearchParams searchParams);
        Task<RestResponse> GetWeightData(IWeightReadingsSearchParams searchParams);
        string DefaultErrorMessage { get; }
    }
}
