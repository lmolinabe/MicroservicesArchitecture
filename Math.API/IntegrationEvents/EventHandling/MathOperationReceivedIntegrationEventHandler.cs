using EventBus.Abstractions;
using Math.API.IntegrationEvents.Events;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.API.IntegrationEvents.EventHandling
{
    public class MathOperationReceivedIntegrationEventHandler : IIntegrationEventHandler<MathOperationReceivedIntegrationEvent>
    {
        private readonly ILogger<MathOperationReceivedIntegrationEventHandler> _logger;

        public MathOperationReceivedIntegrationEventHandler(ILogger<MathOperationReceivedIntegrationEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(MathOperationReceivedIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                //Process the math operation
            }
        }
    }
}
