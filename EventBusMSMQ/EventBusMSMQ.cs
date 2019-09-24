using EventBus;
using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Messaging;
using System.Text;

namespace EventBusMSMQ
{
    public class EventBusMSMQ : IEventBus, IDisposable
    {
        private readonly ILogger<EventBusMSMQ> _logger;
        private readonly IEventBusSubscriptionsManager _subscriptionsManager;
        private string _queueName;

        public EventBusMSMQ(ILogger<EventBusMSMQ> logger, IEventBusSubscriptionsManager subscriptionsManager, string queueName = null)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _subscriptionsManager = subscriptionsManager ?? new InMemoryEventBusSubscriptionsManager();
            _queueName = queueName;
        }

        public void Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            _logger.LogTrace("Publishing event to MSMQ: {EventId}", @event.Id);

            MessageQueue myQueue = new MessageQueue(_queueName);
            myQueue.Send(body);
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = _subscriptionsManager.GetEventKey<T>();

            _logger.LogInformation("Subscribing to event {EventName} with {EventHandler}", eventName, typeof(TH).Name);

            _subscriptionsManager.AddSubscription<T, TH>();
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = _subscriptionsManager.GetEventKey<T>();

            _logger.LogInformation("Unsubscribing from event {EventName}", eventName);

            _subscriptionsManager.RemoveSubscription<T, TH>();
        }

        public void Dispose()
        {
            _subscriptionsManager.Clear();
        }
    }
}
