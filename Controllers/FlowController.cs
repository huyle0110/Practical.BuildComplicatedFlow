using Microsoft.AspNetCore.Mvc;
using Practice.BuildComplicatedFlow.Interface;

namespace Practice.BuildComplicatedFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlowController : ControllerBase
    {
        private readonly ILogger<FlowController> _logger;
        private readonly IMainService _mainService;
        public FlowController(ILogger<FlowController> logger, IMainService mainService)
        {
            _logger = logger;
            _mainService = mainService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _mainService.ExecuteAsync();
            return Ok();
        }
    }
}
