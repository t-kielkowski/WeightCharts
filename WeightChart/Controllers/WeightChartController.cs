﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeightCharts.Application.Feature.Beehive;
using WeightCharts.Application.Feature.GetBeehiveList;
using WeightCharts.Application.Feature.GetMoistureData;
using WeightCharts.Application.Feature.GetWeightData;

namespace WeightCharts.Controllers
{
    public class WeightChartController : BaseController
    {
        private readonly JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public WeightChartController(IMediator mediator, ILogger<WeightChartController> logger) : base(mediator, logger)
        {}

        public async Task<IActionResult> GetBeehiveList()
        {
            var command = new GetBeehiveListQuery();
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result.IsValid && result.Data is not null)
            {
                var model = new
                {
                    BeehiveList = result.Data,
                };

                ViewBag.DataPoints = JsonConvert.SerializeObject(model, _jsonSetting);
                return View();
            }

            return BadRequest(result);
        }

        public async Task<IActionResult> GetTempData(string beehiveId, DateTime? dateFrom, DateTime? dateTo)
        {
            var searchParams = CreateSearchParams(beehiveId, dateFrom, dateTo);
            var command = new GetSensorTempDataQuery(searchParams);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result.IsValid && result.Data is not null)
            {            
                var model = new
                {
                    result.Data.Temperature,
                    result.Data.ReadingTime
                };

                ViewBag.DataPoints = JsonConvert.SerializeObject(model, _jsonSetting);
                return View("Temperature");
            }

            return BadRequest(result);
        } 

        public async Task<IActionResult> GetMoisData(string beehiveId, DateTime? dateFrom, DateTime? dateTo)
        {
            var searchParams = CreateSearchParams(beehiveId, dateFrom, dateTo);
            var command = new GetSensorMoisDataQuery(searchParams);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result.IsValid && result.Data is not null)
            {
                var model = new
                {
                    result.Data.Moisture,
                    result.Data.ReadingTime
                };

                ViewBag.DataPoints = JsonConvert.SerializeObject(model, _jsonSetting);
                return View();
            }

            return BadRequest(result);
        }

        public async Task<IActionResult> GetWeightData(string beehiveId, DateTime? dateFrom, DateTime? dateTo)
        {
            var searchParams = CreateSearchParams(beehiveId, dateFrom, dateTo);
            var command = new GetSensorWeightDataQuery(searchParams);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result.IsValid && result.Data is not null)
            {
                var model = new
                {
                    result.Data.Weight,
                    result.Data.ReadingTime
                };

                ViewBag.DataPoints = JsonConvert.SerializeObject(model, _jsonSetting);
                return View();
            }

            return BadRequest(result);
        }       
    }
}
