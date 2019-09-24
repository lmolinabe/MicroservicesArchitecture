using EventBus.Abstractions;
using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus
{
    public interface IEventBusSubscriptionsManager
    {
        event EventHandler<string> OnEventRemoved;

        void AddSubscription<T, TH>()
           where T : IntegrationEvent
           where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>()
             where TH : IIntegrationEventHandler<T>
             where T : IntegrationEvent;

        void Clear();

        string GetEventKey<T>();
    }
}
