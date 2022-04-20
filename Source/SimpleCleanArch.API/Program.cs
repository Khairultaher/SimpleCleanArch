using SimpleCleanArch.Infrastructure;
using SimpleCleanArch.Application;
using SimpleCleanArch.Application.Common;
using SimpleCleanArch.API.Services;
using SimpleCleanArch.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using SimpleCleanArch.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

#region Configuration
builder.Configuration.AddJsonFile($"appsettings.json", false, true);
//var env = builder.Configuration.GetSection("Environment").Value;
//builder.Configuration.AddJsonFile($"appsettings.{env}.json", false, true);
//IConfiguration configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{env}.json").Build();
IConfiguration configuration = builder.Configuration;
#endregion

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();








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
