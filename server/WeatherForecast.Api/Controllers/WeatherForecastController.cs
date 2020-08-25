using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Api.Application.Queries;

namespace WeatherForecast.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]bool forceRefresh = false)
        {
            try
            {
                var response = await _mediator.Send(new GetWeatherForecast(forceRefresh));
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Error reporting/logging
                return Problem($"Could not retrieve latest weather forecast information: {ex.Message}");
            }
        }
    }
}