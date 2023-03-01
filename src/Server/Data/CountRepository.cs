using Microsoft.AspNetCore.Mvc;
using blaze1.Shared;
using Microsoft.AspNetCore.SignalR;
using blaze1.Server.Hubs;

namespace blaze1.Server.Data;

public class CountRepository
{
    private readonly ILogger<CountRepository> _logger;
    private readonly IHubContext<CountHub> _countHub;
    private int count;

    public CountRepository(ILogger<CountRepository> logger, IHubContext<CountHub> countHub)
    {
        _logger = logger;
        _countHub = countHub;
    }

    public  ValueTask<int> GetCount()
    {
        _logger.LogInformation("GetCount {CurrentCount}", count);
        return ValueTask.FromResult(count);
    }

    public async ValueTask Increment()
    {
        _logger.LogInformation("Incrementing count from {CurrentCount}", count);
        count++;
        await _countHub.Clients.All.SendAsync("UpdatedCount", count);
    }
}
