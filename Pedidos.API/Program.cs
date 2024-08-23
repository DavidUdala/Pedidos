using Microsoft.EntityFrameworkCore;
using Pedidos.Infra.Contextos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PedidosContexto>((options) =>
{
    options
        .UseSqlServer(builder.Configuration["ConnectionStrings:PedidosProdutosDB"]);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
