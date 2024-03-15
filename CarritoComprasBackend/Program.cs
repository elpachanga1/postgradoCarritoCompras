using AutoMapper;
using DataRepository.Data;
using DataRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Domain.Services;
using ShoppingCartBackEnd.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(Program), typeof(Services.MappingProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")), ServiceLifetime.Scoped);


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddProductServices();
builder.Services.AddStoreServices();
builder.Services.AddShoppingCartServices();
builder.Services.AddUserServices();
builder.Services.AddItemServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowReactApp",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
