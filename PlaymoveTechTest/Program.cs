using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlaymoveTechTest.Application.Services.Suppliers;
using PlaymoveTechTest.Data.Context;
using PlaymoveTechTest.Data.Repositories;
using PlaymoveTechTest.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PlaymoveTechTest",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Gabriel Romário da Costa",
            Email = "gabriel.rcosta57@gmail.com",
            Url = new Uri("https://github.com/gabrielromario13")
        }
    });

    var xmlFile = "PlaymoveTechTest.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

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
