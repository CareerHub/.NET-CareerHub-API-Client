using Autofac;
using CareerHub.Client.API.Authorization;
using CareerHub.Client.Framework.API;
using CareerHub_API_ASPNET.Framework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerHub_API_ASPNET.Framework {
    public class FrameworkModule : Module {

        protected override void Load(ContainerBuilder builder) {
            builder
                .RegisterType<CareerHubConfig>()
                .As<ICareerHubConfig>()
                .SingleInstance();

            builder
                .RegisterType<AuthorizationApi>()
                .As<IAuthorizationApi>()
                .SingleInstance();

            builder
                .RegisterType<ApiFactory>()
                .As<IApiFactory>()
                .SingleInstance();
        }
    }
}