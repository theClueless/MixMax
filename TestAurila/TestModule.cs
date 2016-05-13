namespace TestAurila
{
    using System.Collections.Generic;
    using System.IO;

    using Nancy;

    public class TestModule : NancyModule
    {
        public TestModule()
        {
            this.Get["/"] = p => this.View["content/index.html"];
            this.Get["/{anything}"] = p =>
                {
                    string t = (string)p.anything;
                    return Response;
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
