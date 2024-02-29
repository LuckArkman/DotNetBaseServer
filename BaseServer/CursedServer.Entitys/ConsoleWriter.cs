using Microsoft.Extensions.Hosting;
using System.Net;

namespace CursedServer.Entitys;

public class ConsoleWriter : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        DateTime dataDoEvento = new DateTime(2024, 2, 28, 20, 15, 0);
        TimeSpan tempoRestante = dataDoEvento - DateTime.Now;
        Console.WriteLine((int)tempoRestante.Milliseconds);
        if (tempoRestante.TotalSeconds < 0)
        {
            Console.WriteLine("Server Is Only!");
            return;
        }
        Console.WriteLine($"Aguardando até {dataDoEvento}. Para Abrir Servidor.");
        Thread.Sleep((int)tempoRestante.TotalMilliseconds);
        Server server = new Server(IPAddress.Any.ToString(), 3333);
        Console.WriteLine($"{dataDoEvento} Server Is Only! ...");
        Console.WriteLine((int)tempoRestante.Milliseconds);
        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {        
        await Task.CompletedTask;
    }
}