using Autofac;
using Autofac.Integration.Mvc;
using CareerHub_API_ASPNET.Areas.Integrations.Framework;
using CareerHub_API_ASPNET.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CareerHub_API_ASPNET {
    public class AutoFac {
        public static void RegisterContainer() {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(AutoFac).Assembly);
            
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();

            builder.RegisterModule(new FrameworkModule());
            builder.RegisterModule(new IntegrationsModule());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}