using MixMax.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var config = MMMConfig.GetConfig();


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MixMaxService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
