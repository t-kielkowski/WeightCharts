using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeightCharts.Application.Feature.Beehive;

namespace WeightCharts.Controllers
{
    public class WeightChartController : BaseController
    {
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public WeightChartController(ILogger<WeightChartController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Sht31()
        {
            var command = new GetSensorDataQuery(7);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            //var model = new
            //{
            //    Temperature = temp,
            //    Moisture = mois,
            //};

            //ViewBag.DataPoints = JsonConvert.SerializeObject(model, _jsonSetting);

            return View();
        }

        //public async Task<IActionResult> BMP280()
        //{
        //    var bmp280Data = await _allSensorData.bMP280Repository.GetAllAsync();
        //    var viewModel = bmp280Data.Select(Sht31ViewModel.ToTemperatureViewModel);
        //    ViewBag.DataPoints = JsonConvert.SerializeObject(viewModel, _jsonSetting);

        //    return View();
        //}

        //public async Task<IActionResult> BH1750()
        //{
        //    var bh1750Data = await _allSensorData.bH1750Repository.GetAllAsync();
        //    var viewModel = bh1750Data.Select(Sht31ViewModel.ToTemperatureViewModel);
        //    ViewBag.DataPoints = JsonConvert.SerializeObject(viewModel, _jsonSetting);

        //    return View();
        //}

        //public async Task<IActionResult> HDC1080()
        //{
        //    var hdc1080Data = await _allSensorData.hDC1080Repository.GetAllAsync();
        //    var viewModel = hdc1080Data.Select(Sht31ViewModel.ToTemperatureViewModel);
        //    ViewBag.DataPoints = JsonConvert.SerializeObject(viewModel, _jsonSetting);

        //    return View();
        //}

        //public async Task<IActionResult> SoilMoiSoilMoisturesture()
        //{
        //    var soilMoistureData = await _allSensorData.soilMoistureRepository.GetAllAsync();
        //    var viewModel = soilMoistureData.Select(Sht31ViewModel.ToTemperatureViewModel);
        //    ViewBag.DataPoints = JsonConvert.SerializeObject(viewModel, _jsonSetting);

        //    return View();
        //}

       
    }
}
