using Microsoft.AspNetCore.Mvc;
using SimpleCleanArch.Application.Common.Extensions;
using SimpleCleanArch.Application.Common.Models;
using SimpleCleanArch.Application.WeatherForecasts.Commands;
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

        [HttpGet]
        public async Task<ActionResult<PaginatedList<WeatherForecastModel>>> GetWeatherForecastWithPagination([FromQuery] GetWeatherForecastWithPaginationQuery query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetExceptions());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateWeatherForecastCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetExceptions());
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateWeatherForecastCommand command)
        {
            try
            {
                await Mediator.Send(command);
                response.Message = "Item updated successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetExceptions());
            }
        }



        //[HttpDelete("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await Mediator.Send(new DeleteWeatherForecastCommand { Id = id });
                response.Message = "Item deleted successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetExceptions());
            }
        }
    }
}