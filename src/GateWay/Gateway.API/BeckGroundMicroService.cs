
namespace Gateway.API;

public class BeckGroundMicroService : BackgroundService, IHostedService, IHostedLifecycleService
{
    private readonly ILogger<BeckGroundMicroService> _logger;

    public BeckGroundMicroService(ILogger<BeckGroundMicroService> logger)
    {
        _logger = logger;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StartingAsync(CancellationToken cancellationToken)
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

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
