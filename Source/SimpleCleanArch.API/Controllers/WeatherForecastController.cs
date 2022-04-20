using Microsoft.AspNetCore.Mvc;
using SimpleCleanArch.Application.Common.Models;
using SimpleCleanArch.Application.WeatherForecasts.Queries;

namespace SimpleCleanArch.API.Controllers
{
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetWeatherForecast")]
        public async Task<ActionResult<PaginatedList<WeatherForecastModel>>> GetWeatherForecastWithPagination([FromQuery] GetWeatherForecastWithPaginationQuery query)
        {
            try
            {
                //await Task.Delay(5000);
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int skip = 1, int take = 10)
        {
            try
            {

                await Task.Delay(5000);
                var data = await Task.FromResult(Enumerable.Range(1, 20).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList());

                var res = new { data = data.Skip(skip - 1).Take(take).ToList(), count = data.Count() };

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new { message = ex.Message };
                return BadRequest(res);
            }
        }
    }
}