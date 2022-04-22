using SimpleCleanArch.Domain.Common;
using SimpleCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCleanArch.Domain.Events
{
    public class WeatherForecastCreatedEvent : DomainEvent
    {
        public WeatherForecastCreatedEvent(WeatherForecast item)
        {
            Item = item;
        }

        public WeatherForecast Item { get; }
    }
}
