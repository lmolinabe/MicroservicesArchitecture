using EventBus.Events;
using System.Threading.Tasks;

namespace Math.API.IntegrationEvents
{
    public interface IMathOperationIntegrationEventService
    {
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
