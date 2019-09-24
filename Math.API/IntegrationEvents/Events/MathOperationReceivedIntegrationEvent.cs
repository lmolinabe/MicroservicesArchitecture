using EventBus.Events;
using Math.API.Model;

namespace Math.API.IntegrationEvents.Events
{
    public class MathOperationReceivedIntegrationEvent : IntegrationEvent
    {
        public MathOperation MathOperation { get; set; }

        public MathOperationReceivedIntegrationEvent(MathOperation mathOperation)
        {
            MathOperation = mathOperation;
        }
    }
}
