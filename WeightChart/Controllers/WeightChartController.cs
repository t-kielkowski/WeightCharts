using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeightChart.Infrastructure.Repository;
using WeightCharts.ViewModel;

namespace WeightCharts.Controllers
{
    public class WeightChartController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAllSensorData _allSensorData;
        private readonly JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public WeightChartController(ILogger<WeightChartController> logger, IAllSensorData allSensorData)
        {
            _logger = logger;
            _allSensorData = allSensorData;
        }

        public async Task<IActionResult> Sht31()
        {
            var sht31Data = await _allSensorData.sHT31Repository.GetAllAsync();
            var viewModel = sht31Data.Select(Sht31ViewModel.ToTemperatureViewModel);
            ViewBag.DataPoints = JsonConvert.SerializeObject(viewModel, _jsonSetting);

            return View();
        }
    }
}
