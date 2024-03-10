using AutoMapper;
using DataRepository.Data;
using DataRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Domain.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(Program), typeof(Services.MappingProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")), ServiceLifetime.Scoped);


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Configuración de Fábricas
//builder.Services.AddTransient<ProductFactory>();
builder.Services.AddTransient<ProductFactory>(serviceProvider =>
{
    var mapper = serviceProvider.GetRequiredService<IMapper>();
    var productRepository = serviceProvider.GetRequiredService<IRepository<DataRepository.Models.Product>>();    
    return new ProductFactory(mapper, productRepository);
});

//builder.Services.AddTransient<UserFactory>();
//builder.Services.AddTransient<ProductService>();
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
