using Microsoft.EntityFrameworkCore;
using Pedidos.API.Services;
using PedidosAPI.HttpClients;
using PedidosAPI.Persistence;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

builder.Services.AddServiceDiscovery(options => options.UseConsul());


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PedidoDbContext>(options => options.UseInMemoryDatabase("pedidos"));
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<PedidoService>();

builder.Services.AddProblemDetails();

builder.Services.AddHttpClient<PizzaApiHttpClient.Client>(options =>
{
    options.BaseAddress = new Uri("http://pizza-service");
}).AddServiceDiscovery();
builder.Services.AddHttpClient<NotificacoesApiHttpClient.Client>("notificacao", options =>
{
    options.BaseAddress = new Uri("http://notificacoes-service");
}).AddServiceDiscovery();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler("/error");

app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
