using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<WeatherForecast> WeatherForecasts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}