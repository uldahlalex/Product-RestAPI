using API.DTOs;
using AutoMapper;
using Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Making a mapper configuration
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<PostProductDTO, Product>();
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlite(
        "Data source=db.db"
    ));
builder.Services.AddScoped<ProductRepository>();

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