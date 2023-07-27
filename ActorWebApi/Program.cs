using ActorWebApi.Models;
using ActorWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Database Connection
var ConnectionString = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<SakilaContext>(options =>
options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

// Add services to the container.
builder.Services.AddScoped<ICityOps, CityOps>();

// Authomapper Configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
