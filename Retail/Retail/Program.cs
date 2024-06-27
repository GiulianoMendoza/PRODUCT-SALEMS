using Application.Interfaces;
using Application.Mapper;
using Application.UseCase;
using Infraestructure.Comand;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "ratail",
    });

    //Swagger Documentation
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
//custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(connectionString));
//product
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCommand, ProductCommand>();
builder.Services.AddScoped<IProductquery, ProductQuery>();
builder.Services.AddScoped<IProductMapper, ProductMapper>();
//sale
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleCommand, SaleCommand>();
builder.Services.AddScoped<ISaleQuery, SaleQuery>();
builder.Services.AddScoped<ISaleMapper, SaleMapper>();
//saleproduct
builder.Services.AddScoped<ISaleProductService, SaleProductService>();
builder.Services.AddScoped<ISaleProductCommand, SaleProductCommand>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
