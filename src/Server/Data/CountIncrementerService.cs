using Microsoft.AspNetCore.Mvc;
using blaze1.Shared;
using Microsoft.AspNetCore.SignalR;
using blaze1.Server.Hubs;

namespace blaze1.Server.Data;

public class CountIncrementerService : BackgroundService
{
    private readonly ILogger<CountIncrementerService> _logger;
    private readonly CountRepository _countRepository;

    public CountIncrementerService(ILogger<CountIncrementerService> logger, CountRepository countRepository)
    {
        _logger = logger;
        _countRepository = countRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var random = new Random();
        while (!stoppingToken.IsCancellationRequested)
        {
            var waitSeconds = random.Next(2, 5);
            await Task.Delay(TimeSpan.FromSeconds(waitSeconds), stoppingToken);

            await _countRepository.Increment();
        }
    }
}
