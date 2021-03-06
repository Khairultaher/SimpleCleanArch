using MediatR;
using SimpleCleanArch.Application.Common.Interfaces;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCleanArch.Application.WeatherForecasts.Commands
{
    public class CreateWeatherForecastCommand : IRequest<int>
    {
        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }

    public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateWeatherForecastCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var entity = new WeatherForecast
            {
                TemperatureC = request.TemperatureC,
                CreatedAt = DateTime.UtcNow,
                Summary = request.Summary,
            };

            entity.DomainEvents.Add(new WeatherForecastCreatedEvent(entity));

            _context.WeatherForecasts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
