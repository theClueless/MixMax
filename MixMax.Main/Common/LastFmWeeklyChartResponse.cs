using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Common
{
    //public class Image
    //{
    //    public string __invalid_name__text { get; set; }
    //    public string size { get; set; }
    //}

    public class Attr2
    {
        public string user { get; set; }
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Weeklytrackchart
    {
        public List<LastFmTrack> track { get; set; }
        public Attr2 __invalid_name__attr { get; set; }
    }

    public class WeeklyCharRootObject
    {
        public Weeklytrackchart weeklytrackchart { get; set; }
    }
}
