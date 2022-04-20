using AutoMapper;
using SimpleCleanArch.Application.Common.Mappings;
using SimpleCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCleanArch.Application.WeatherForecasts.Queries
{
    public class WeatherForecastModel : IMapFrom<WeatherForecast>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WeatherForecast, WeatherForecastModel>();
        }
    }
}
