using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Common
{
    public class RootObject
    {
        [JsonProperty("track")]
        public LastFmTrack track { get; set; }
    }

    public class LastFmTrack
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public string duration { get; set; }
        public string listeners { get; set; }
        public string playcount { get; set; }
        public Artist artist { get; set; }
        public Album album { get; set; }
        public Toptags toptags { get; set; }
        public Wiki wiki { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
    }

    public class Attr
    {
        public string position { get; set; }
    }

    public class Album
    {
        public string artist { get; set; }
        public string title { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Toptags
    {
        public List<Tag> tag { get; set; }
    }

    public class Wiki
    {
        public string published { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
    }    
}
