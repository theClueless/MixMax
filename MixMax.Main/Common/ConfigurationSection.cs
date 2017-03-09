using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Common
{
    public class MMMConfig : ConfigurationSection
    {
        [ConfigurationProperty("RootFolders")]
        [ConfigurationCollection(typeof(RootFolder), AddItemName = "RootFolder")]
        public RootFolders RootFolders
        {
            get
            {
                object o = this["RootFolders"];
                return o as RootFolders;
            }
        }

        public static MMMConfig GetConfig()
        {
            return (MMMConfig)System.Configuration.ConfigurationManager.GetSection("RootFolders") ?? new MMMConfig();
        }
    }

    public class RootFolders : ConfigurationElementCollection
    {
        public RootFolder this[int index]
        {
            get
            {
                return base.BaseGet(index) as RootFolder;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new RootFolder this[string responseString]
        {
            get { return (RootFolder)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new RootFolder();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((RootFolder)element).Name;
        }
    }


    public class RootFolder : ConfigurationElement
    {

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get
            {
                return this["path"] as string;
            }
        }
    }
}
