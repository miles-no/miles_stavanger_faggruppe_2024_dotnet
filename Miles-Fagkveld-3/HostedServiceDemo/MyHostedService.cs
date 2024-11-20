namespace HostedServiceDemo;

public class MyHostedService : IHostedService
{
    private readonly ILogger<MyHostedService> _logger;

    public MyHostedService(ILogger<MyHostedService> logger)
    {
        _logger = logger;
    }

    //public async Task StartAsync(CancellationToken cancellationToken)
    //{
    //    _logger.LogInformation("Starting MyHostedService");

    //    await Task.Delay(100000, cancellationToken);
    //}

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting MyHostedService");

        while (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTime.Now.ToString("O"));

            await Task.Delay(1000, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping MyHostedService");

        return Task.CompletedTask;
    }
}
