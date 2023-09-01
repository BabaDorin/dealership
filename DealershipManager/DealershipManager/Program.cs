using DealershipManager.Data;
using DealershipManager.Middleware;
using DealershipManager.Repositories;
using DealershipManager.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, SqlCarRepository>();
builder.Services.AddScoped<ICarValidator, CarValidator>();
//builder.Services.AddScoped<ICarRepository, InMemoryCarRepository>();

builder.Services.AddScoped<IClientRepository, SqlClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientValidator, ClientValidator>();
//builder.Services.AddScoped<IClientRepository, InMemoryClientRepository>();

builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleRepository, SqlSaleRepository>();
//builder.Services.AddScoped<ISaleRepository, InMemorySaleRepository>();
// CTRL + K + C to comment
// CTRL + K + U to uncomment

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline // middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
