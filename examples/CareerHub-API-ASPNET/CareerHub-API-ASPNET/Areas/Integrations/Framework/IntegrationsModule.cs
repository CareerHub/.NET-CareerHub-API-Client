using Autofac;
using CareerHub_API_ASPNET.Areas.Integrations.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerHub_API_ASPNET.Areas.Integrations.Framework {
    public class IntegrationsModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder
                .RegisterType<FormReportsService>()
                .As<IFormReportsService>();
        }
    }
}