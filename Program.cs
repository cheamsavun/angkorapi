using Angkorsoft.Core;
using AngkorAPI.Infrastructure;
using Angkorsoft.Core.Security;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.ConfigureInfrastructure();

services.AddHostedService<DataSeedService>();

var app = services.BuildWebApp(builder);
app.EnsureMigration<AppDbContext>();

var serviceProvider = app.Services.CreateScope().ServiceProvider;

PermissionList.Register(typeof(PermissionScope));

var logger = serviceProvider.GetRequiredService<ILogger>();
try
{
  await app.RunAsync();
}
catch (Exception ex)
{
  foreach (var msg in ex.DrilldownMessages())
    logger.LogError(msg);
}
