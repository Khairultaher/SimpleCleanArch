using FluentValidation;

namespace SimpleCleanArch.Application.WeatherForecasts.Commands.Create
{
    public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
    {
        public CreateWeatherForecastCommandValidator()
        {
            RuleFor(v => v.Summary)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.TemperatureC)
                .NotNull().WithMessage("Title is required.")
                .GreaterThanOrEqualTo(1).WithMessage("Temperature(C) at least greater than or equal to 1.");
        }
    }
}
