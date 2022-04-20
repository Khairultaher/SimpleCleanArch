using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCleanArch.Infrastructure.Persistence.Configurations;

public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.Ignore(e => e.TemperatureF);

        builder.Property(t => t.Summary)
            .HasMaxLength(250)
            .IsRequired();
    }
}
