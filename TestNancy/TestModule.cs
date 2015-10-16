using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNancy
{
    using System.Reflection;

    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Diagnostics.Modules;
    using Nancy.TinyIoc;
    using Nancy.ViewEngines;

    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get["/"] = p => View["Main.html"];
        }
    }

    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(OnConfigurationBuilder);
            }
        }

        void OnConfigurationBuilder(NancyInternalConfiguration x)
        {
            x.ViewLocationProvider = typeof(ResourceViewLocationProvider);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            ResourceViewLocationProvider.RootNamespaces.Add(
              Assembly.GetAssembly(typeof(TestModule)), "TestNancy.Views");
        }
    }
}
