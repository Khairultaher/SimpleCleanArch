using MediatR;
using SimpleCleanArch.Application.Common.Exceptions;
using SimpleCleanArch.Application.Common.Interfaces;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Application.WeatherForecasts.Commands
{
    public class UpdateWeatherForecastCommand : IRequest
    {
        public int Id { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }

    public class UpdateWeatherForecastCommandHander : IRequestHandler<UpdateWeatherForecastCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateWeatherForecastCommandHander(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.WeatherForecasts.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(WeatherForecast), request.Id);
            }

            entity.TemperatureC = request.TemperatureC;
            entity.Summary = request.Summary;


            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
