using reportBgService;
using reportBgService.Models;
using reportBgService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        hostContext.Configuration.GetSection("AppSettings");
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
