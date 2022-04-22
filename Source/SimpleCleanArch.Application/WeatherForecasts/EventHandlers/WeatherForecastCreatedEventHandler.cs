using MediatR;
using Microsoft.Extensions.Logging;
using SimpleCleanArch.Application.Common.Models;
using SimpleCleanArch.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCleanArch.Application.WeatherForecasts.EventHandlers
{
    public class WeatherForecastCreatedEventHandler : INotificationHandler<DomainEventNotification<WeatherForecastCreatedEvent>>
    {
        private readonly ILogger<WeatherForecastCreatedEventHandler> _logger;

        public WeatherForecastCreatedEventHandler(ILogger<WeatherForecastCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<WeatherForecastCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
