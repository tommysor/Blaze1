using Microsoft.AspNetCore.Mvc;
using blaze1.Shared;
using Microsoft.AspNetCore.SignalR;

namespace blaze1.Server.Hubs;

public class CountHub : Hub
{
    private readonly ILogger<CountHub> _logger;

    public CountHub(ILogger<CountHub> logger)
    {
        _logger = logger;
    }
}
