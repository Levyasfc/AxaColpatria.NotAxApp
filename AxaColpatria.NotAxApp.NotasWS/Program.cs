using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Infraestructure.Data;
using AxaColpatria.NotAxApp.Infraestructure.Repositories;
using AxaColpatria.NotAxApp.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

 // Conexion a DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registrar repositorio y servicio
builder.Services.AddScoped<INotaRepository, NotaRepository>();
builder.Services.AddScoped<INotaService, NotaService>();

builder.Services.AddScoped<ITableroRepository, TableroRepository>();
builder.Services.AddScoped<ITableroService, TableroService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();