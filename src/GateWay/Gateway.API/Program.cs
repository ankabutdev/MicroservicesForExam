using Gateway.API;
using JwtService.Core;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHostedService<BackGroundMicroService>();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);
//builder.Services.AddCustomJwtLayer();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();
app.Run();