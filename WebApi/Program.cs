using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Helpers.Automapper;
using Helpers.Validation;
using Infra.Database;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.VariaveisAmbiente;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ExercicioValidation>();

// Adiciona AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

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

//Injeção de dependência
builder.Services.AddScoped<IExercicioRepository, ExercicioRepository>();
builder.Services.AddScoped<IExercicioService, ExercicioService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IVariacaoRepository, VariacaoRepository>();
builder.Services.AddScoped<IVariacaoService, VariacaoService>();
builder.Services.AddScoped<IOrquestracaoService, OrquestracaoService>();
builder.Services.AddScoped<Variaveis>();
builder.Services.AddScoped<VariaveisService>();
builder.Services.AddScoped<IVariaveisService, VariaveisService>();
builder.Services.Configure<Variaveis>(builder.Configuration.GetSection("AppSettings"));

string chaveToken = builder.Configuration["AppSettings:ChaveToken"];
string issuerToken = builder.Configuration["AppSettings:IssuerToken"];
string audienceToken = builder.Configuration["AppSettings:AudienceToken"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuerToken,
        ValidAudience = audienceToken,
        IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveToken))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devClient = "http.//localhost:4200";
app.UseCors(x =>
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins(devClient));

app.UpdateDatabase();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
