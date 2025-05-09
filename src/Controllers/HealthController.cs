using Microsoft.AspNetCore.Mvc;

namespace orderflow.gateway.Controllers;
/// <summary>
/// This controller provides health checks for this microservice.
/// </summary>
[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="HealthController"/> class.
    /// </summary>
    public HealthController()
    {
    }
    #endregion
    #region Actions
    /// <summary>
    /// Gets the current health status of the microservice.
    /// </summary>
    /// <returns>A 200 OK, indicating the microservice is healthy.</returns>
    /// <response code="200">Successful operation.</response>
    [HttpGet("GetStatus")]
    public IActionResult GetStatus()
    {
        return Ok(new { status = "Gateway Healthy", timestamp = DateTime.UtcNow });
    }
    #endregion
}
