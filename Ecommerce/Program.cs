using Ecommerce;
using Ecommerce.Interfaces;
using Ecommerce.Interfaces.DataConnector;
using Ecommerce.Interfaces.Repositories;
using Ecommerce.Repositories;
using Ecommerce.Repositories.DataConnector;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .AddCommandLine(args)
        .Build();

builder.Services.AddScoped<IServiceConnector>(x => new ServiceConnector(config.GetConnectionString("default")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUtils, Utils>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
