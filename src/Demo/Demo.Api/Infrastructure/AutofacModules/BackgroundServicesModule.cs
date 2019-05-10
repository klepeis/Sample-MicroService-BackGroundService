using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Demo.Api.Services;
using Microsoft.Extensions.Hosting;

namespace Demo.Api.Infrastructure.AutofacModules
{
    public class BackgroundServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>()
                .As<IHostedService>()
                .SingleInstance();
        }
    }
}
