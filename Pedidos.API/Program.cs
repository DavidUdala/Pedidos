using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Interfaces.Repositorios;
using Pedidos.Dominio.Mapper;
using Pedidos.Infra.Contextos;
using Pedidos.Infra.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PedidosContexto>((options) =>
{
    options
        .UseSqlServer(builder.Configuration["ConnectionStrings:PedidosDB"]);
});

builder.Services.AddScoped<IPedidoRepositorio, PedidosRepositorio>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
