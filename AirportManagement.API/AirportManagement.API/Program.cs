﻿using AirportManagement.API.Data;
using AirportManagement.API.Data.Services;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Name=SQLLiteDBmacOS"));

builder.Services.AddScoped<IPassangerRepository, PassangerRepository>();
builder.Services.AddScoped<IAirLineRepository,AirlineRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IBaggageRepository, BaggageRepository>();
builder.Services.AddScoped<IBaggageCheckRepository, BaggageCheckRepository>();
builder.Services.AddScoped<IFlightsRepository, FlightsRepository>();
builder.Services.AddScoped<IBoardingPassRepository, BoardingPassRepository>();

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

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

SeedData.Seed(app);

app.Run();