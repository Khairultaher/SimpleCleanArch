using SimpleCleanArch.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCleanArch.Domain.Entities
{
    [Table("WeatherForecasts", Schema = "dbo")]
    public class WeatherForecast : AuditableEntity, IHasDomainEvent
    {
        public WeatherForecast()
        {
        }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
