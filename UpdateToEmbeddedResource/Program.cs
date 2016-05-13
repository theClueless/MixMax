using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateToEmbeddedResource
{
    using System.IO;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var projPath = Directory.GetFiles(path, "*.csproj").First();
            var xml = XElement.Load(projPath);
            foreach (var element in xml.Descendants().Where(x=>x.Name.LocalName == "Content" ||
            x.Name.LocalName == "None"))
            {
                var include = element.Attribute("Include");
                if (include != null && include.Value.StartsWith("content"))
                {
                    element.Name = "EmbeddedResource";
                    element.Add(new XElement("CopyToOutputDirectory", "PreserveNewest"));
                }
            }

            xml.Save(projPath);
        }
    }
}
