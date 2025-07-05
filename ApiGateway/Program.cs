var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
   
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapReverseProxy();

app.UseAuthorization();

app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
