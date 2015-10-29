using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNancy
{
    using System.IO;
    using System.Reflection;

    using Nancy;
    using Nancy.Diagnostics.Modules;

    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get["/"] = p => View["content/Views/Main.html"];
            Get["/Main.html"] = p => View["content/Views/Main.html"];
            Get["/allFileView.html"] = p => View["content/Views/allFileView.html"];
            Get["/generatePlaylist"] = p =>
                {
                    var playList = new PlayList { Name = "First", SongCount = 20 };
                    var playList2 = new PlayList { Name = "Second", SongCount = 202 };
                    var playList3 = new PlayList { Name = "Thrid", SongCount = 1102 };
                    var lists = new List<PlayList> { playList, playList2, playList3 };
                    var r = this.Response.AsJson(lists);
                    r.ContentType = "application/json";
                    return r;
                };
            Get["/getPlaylist/{name}"] = p =>
                {
                    string name = (string)p.name;
                    var rootPath = this.Response.RootPath;
                    var filePath = Path.Combine(rootPath, name + ".txt");
                    using (var f = File.Create(filePath))
                    {
                        f.WriteByte(22);
                        f.WriteByte(22);
                        f.WriteByte(22);
                        f.WriteByte(22);
                        f.WriteByte(22);
                        f.WriteByte(22);
                        f.WriteByte(22);
                        f.WriteByte(22);
                        f.WriteByte(22);
                    }
                    var r = this.Response.AsFile(filePath);
                    return r;
                };
        }
    }

    public class PlayList
    {
        public string Name { get; set; }

        public int SongCount { get; set; }

        public List<Song> Songs { get; set; }
    }

    public class Song
    {
        public string Name { get; set; }
    }
}
