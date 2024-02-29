using CursedServer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
{
    services.AddDbContext<CursedStoneDBContext>(options => options.UseInMemoryDatabase("CursedStoneDB-Memory"));
    services.AddHostedService<ConsoleWriter>();
}).Build().Run();