using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Services;
using Infra.Database;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Entity Framework
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"), sqlServerOptions =>
    {
        sqlServerOptions.CommandTimeout(60); // Tempo limite de comando em segundos
        sqlServerOptions.EnableRetryOnFailure(1); // Tenta novamente 1 vez em caso de falha
    }));

//Inje��o de depend�ncia
builder.Services.AddSingleton<IExercicioRepository, ExercicioRepository>();
builder.Services.AddSingleton<IExercicioService, ExercicioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UpdateDatabase();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
