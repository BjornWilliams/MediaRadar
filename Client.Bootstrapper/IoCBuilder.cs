using Autofac;
using Business.Contracts.Services;
using Business.Services;
using Data.Contracts;
using Data.Store;
using Data.Store.Repositories;
using MediaRadar.Api.Contracts;
using MediaRadar.Api.Services;
using System;
using System.Data.Entity;

namespace Client.Bootstrapper
{
    public class IoCBuilder
    {
        #region Constructors
        public IoCBuilder(ContainerBuilder containerBuilder)
        {
            if (containerBuilder == null) { throw new ArgumentNullException(nameof(containerBuilder)); }

            containerBuilder
                .RegisterType<MediaContext>()
                .AsSelf()
                .As<DbContext>()
                .InstancePerRequest();

            containerBuilder
                .RegisterType<PublicationAdActivityRepository>()
                .As<IPublicationAdActivityRepository>()
                .InstancePerRequest();

            containerBuilder
                .RegisterType<PublicationAdActivityService>()
                .As<IPublicationAdActivityService>()
                .InstancePerLifetimeScope();

            containerBuilder
                .RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            containerBuilder
                .RegisterType<PublicationService>()
                .As<IPublicationService>()
                .InstancePerLifetimeScope();

            Container = containerBuilder.Build();
        }
        #endregion
        #region properties
        public IContainer Container { get; }
        #endregion
    }
}
