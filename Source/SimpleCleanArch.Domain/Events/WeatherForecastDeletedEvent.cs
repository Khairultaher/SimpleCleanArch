using SimpleCleanArch.Domain.Common;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Domain.Events
{
    public class WeatherForecastDeletedEvent : DomainEvent
    {
        public WeatherForecastDeletedEvent(WeatherForecast item)
        {
            Item = item;
        }

        public WeatherForecast Item { get; }
    }
}
