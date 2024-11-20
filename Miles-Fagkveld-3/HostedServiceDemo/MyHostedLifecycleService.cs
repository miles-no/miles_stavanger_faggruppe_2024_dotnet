
namespace HostedServiceDemo;

public class MyHostedLifecycleService : IHostedLifecycleService
{
    private readonly ILogger<MyHostedLifecycleService> _logger;

    public MyHostedLifecycleService(ILogger<MyHostedLifecycleService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private void DoWork()
    {
        _logger.LogInformation("Worker running at: {time}", DateTime.Now.ToString("O"));
    }
}
