using Microsoft.EntityFrameworkCore;
using PedidosAPI.HttpClients;
using PedidosAPI.Persistence;
using PedidosAPI.Services;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDiscovery(options => options.UseConsul());


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PedidoDbContext>(options => options.UseInMemoryDatabase("pedidos"));
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<PedidoService>();

builder.Services.AddHttpClient<PizzaApiHttpClient.Client>(options =>
{
    options.BaseAddress = new Uri("http://pizza-service");
}).AddServiceDiscovery();

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
