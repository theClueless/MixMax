namespace TestAurila
{
    using System.IO;

    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;
    using Nancy.ViewEngines;

    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(this.OnConfigurationBuilder);
            }
        }

        void OnConfigurationBuilder(NancyInternalConfiguration x)
        {
            x.ViewLocationProvider = typeof(ResourceViewLocationProvider);
            var a = this.RootPathProvider.GetRootPath();
        }

        // protected override IRootPathProvider RootPathProvider
        // {
        //     get
        //     {
        //         return new CustomRootPathProvider();
        //     }
        // }

        // public class CustomRootPathProvider : IRootPathProvider
        // {
        //     private DefaultRootPathProvider provider;
        // 
        //     private string path;
        // 
        //     public CustomRootPathProvider()
        //     {
        //         provider = new DefaultRootPathProvider();
        //         path = Path.Combine(provider.GetRootPath(), "content");
        //     }
        // 
        //     public string GetRootPath()
        //     {
        //         return path;
        //     }
        // }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            // ResourceViewLocationProvider.RootNamespaces.Add(
            //   Assembly.GetAssembly(typeof(TestModule)), "TestNancy.Views");
        }
    }
}