using MassTransit;
using Report.Shared.RabbitMq;
using reportBgService.Models;

namespace reportBgService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuraton)
        {
            _logger = logger;
            _configuration = configuraton;
            _appSettings = _configuration.GetSection("AppSettings").Get<AppSettings>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host(new Uri(RabbitMQConstants.Uri), h =>
                        {
                            h.Username(RabbitMQConstants.Username);
                            h.Password(RabbitMQConstants.Password);
                        });

                        cfg.ReceiveEndpoint(RabbitMQConstants.reportServiceQueueName, e =>
                        e.Consumer<ReportCunsomer>());
                    });

                    busControl.Start();
                    Console.WriteLine("Started consuming.");
                    
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}