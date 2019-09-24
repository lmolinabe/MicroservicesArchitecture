using System;
using System.Threading.Tasks;
using Math.API.IntegrationEvents;
using Math.API.IntegrationEvents.Events;
using Math.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Math.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly IMathOperationIntegrationEventService _mathOperationIntegrationEventService;

        public MathController(IMathOperationIntegrationEventService mathOperationIntegrationEventService)
        {
            _mathOperationIntegrationEventService = mathOperationIntegrationEventService ?? throw new ArgumentNullException(nameof(mathOperationIntegrationEventService));
        }

        [HttpPost]
        public async Task<ActionResult> ExecuteMathOperation([FromBody] MathOperation mathOperation)
        {
            var mathOperationReceivedEvent = new MathOperationReceivedIntegrationEvent(mathOperation);

            await _mathOperationIntegrationEventService.PublishThroughEventBusAsync(mathOperationReceivedEvent);

            return CreatedAtAction("ExecuteMathOperation", new { result = 1 }, null);
        }
    }
}
