using Microsoft.AspNetCore.Mvc;
using blaze1.Shared;
using blaze1.Server.Data;

namespace blaze1.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CountController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly CountRepository _countRepository;

    public CountController(ILogger<WeatherForecastController> logger, CountRepository countRepository)
    {
        _logger = logger;
        _countRepository = countRepository;
    }

    [HttpGet]
    public async ValueTask<int> Get()
    {
        return await _countRepository.GetCount();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Post([FromBody]string body)
    {
        if (!"increment".Equals(body, StringComparison.InvariantCultureIgnoreCase))
        {
            return BadRequest($"Invalid body: {body}");
        }

        await _countRepository.Increment();
        return NoContent();
    }
}
