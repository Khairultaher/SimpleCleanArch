using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SimpleCleanArch.API.Filters;
using SimpleCleanArch.API.Services;
using SimpleCleanArch.Application;
using SimpleCleanArch.Application.Common;
using SimpleCleanArch.Application.Common.Constants;
using SimpleCleanArch.Infrastructure;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Configuration
builder.Configuration.AddJsonFile($"appsettings.json", false, true);
var env = builder.Configuration.GetSection("Environment").Value;
builder.Configuration.AddJsonFile($"appsettings.{env}.json", false, true);
//IConfiguration configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{env}.json").Build();                           .Build();
IConfiguration configuration = builder.Configuration;
#endregion

#region Constants & Variables
Constants.JwtSettings.Issuer = configuration["JwtSettings:Issuer"];
Constants.JwtSettings.Audience = configuration["JwtSettings:Audience"];
Constants.JwtSettings.SigningKey = configuration["JwtSettings:SigningKey"];
#endregion

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddControllers(options =>
    options.Filters.Add<ApiExceptionFilterAttribute>())
        .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configure Session
//builder.Services.AddSession(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.IdleTimeout = TimeSpan.FromHours(1);
//});
#endregion

//services cors
builder.Services.AddCors(p => p.AddPolicy("cors", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
