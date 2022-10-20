using Data.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/Latancies")]
    public class LatancyController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILatencyService _latencyService;

        public LatancyController(IConfiguration configuration, ILatencyService latencyService)
        {
            _configuration = configuration;
            _latencyService = latencyService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLatancies([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await _latencyService.GetLatencyResult(startDate, endDate);
            return Ok(result);
        }
    }
}
