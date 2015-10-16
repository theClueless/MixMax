using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNancy
{
    class Program
    {
        static void Main(string[] args)
        {
             var nancyHost = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:9664"));
             nancyHost.Start();
             Console.WriteLine("Web server running...");
             
             Console.ReadLine();
             nancyHost.Stop();
        }
    }
}
