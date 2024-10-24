using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Interfaces;
using WebAplicacion.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TestDbContext>(options => options.UseSqlServer(conString));

//Conexiones de Repositorios y Controllers
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<IComentariosClientesRepository, ComentariosClientesRepository>();
builder.Services.AddScoped<IBuysRepository, BuysRepository>();
builder.Services.AddScoped<IxInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IDatesRepository, DatesRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
