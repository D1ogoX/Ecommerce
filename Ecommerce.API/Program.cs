using Ecommerce.API.Application.Applications;
using Ecommerce.API.Application.Interfaces;
using Ecommerce.API.Application.Mapper;
using Ecommerce.API.Domain.Interfaces.Repositories;
using Ecommerce.API.Domain.Interfaces.Repositories.DataConnector;
using Ecommerce.API.Domain.Interfaces.Services;
using Ecommerce.API.Domain.Services;
using Ecommerce.API.Infra.DataConnector;
using Ecommerce.API.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .AddCommandLine(args)
        .Build();

builder.Services.AddScoped<IServiceConnector>(x => new ServiceConnector(config.GetConnectionString("default")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductApplication, ProductApplication>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
