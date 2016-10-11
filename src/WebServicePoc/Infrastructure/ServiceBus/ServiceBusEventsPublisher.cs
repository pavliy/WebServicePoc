﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccess;

using DomainModel.Common;

namespace WebServicePoc.Infrastructure.ServiceBus
{
    public class ServiceBusEventsPublisher : IEventsPublisher
    {
        private readonly IBus bus;

        public ServiceBusEventsPublisher(IBus bus)
        {
            if (bus == null)
            {
                throw new ArgumentNullException(nameof(bus));
            }

            this.bus = bus;
        }

        public void Publish(IEnumerable<IEvent> newEvents)
        {
            if (newEvents == null)
            {
                throw new ArgumentNullException(nameof(newEvents));
            }

            this.bus.Send(newEvents.ToArray());
        }
    }
}
