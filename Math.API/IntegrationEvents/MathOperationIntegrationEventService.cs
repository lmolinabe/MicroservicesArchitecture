using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using EventBus.Events;
using EventBus;

namespace Math.API.IntegrationEvents
{
    public class MathOperationIntegrationEventService : IMathOperationIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<MathOperationIntegrationEventService> _logger;

        public MathOperationIntegrationEventService(ILogger<MathOperationIntegrationEventService> logger, IEventBus eventBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            try
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId_published} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);

                _eventBus.Publish(evt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);
            }
        }
    }
}
