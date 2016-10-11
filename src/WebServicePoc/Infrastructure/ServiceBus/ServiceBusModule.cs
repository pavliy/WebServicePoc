﻿using Autofac;

using DataAccess;

namespace WebServicePoc.Infrastructure.ServiceBus
{
    public class ServiceBusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceBusEventsPublisher>().As<IEventsPublisher>().InstancePerLifetimeScope();

            builder.RegisterType<Bus>().As<IBus>().SingleInstance();

            base.Load(builder);
        }
    }
}