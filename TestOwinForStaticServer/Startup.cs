namespace TestOwinForStaticServer
{
    using Microsoft.Owin.FileSystems;
    using Microsoft.Owin.StaticFiles;

    using Owin;

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // File Server
            var options = new FileServerOptions
                              {
                                  EnableDirectoryBrowsing = true,
                                  EnableDefaultFiles = true,
                                  DefaultFilesOptions = { DefaultFileNames = { "index.html" } },
                                  FileSystem = new PhysicalFileSystem("static"),
                              };

            app.UseFileServer(options);
        }
    }
}