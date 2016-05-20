using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMax.Main.Common;
using System.IO;

namespace MixMax.Main.Services.TrackListUpdater
{
    public class TrackListUpdater : ITrackListUpdater
    {
        public List<Track> CreateTrackList(string rootFolder, List<Track> tracks)
        {
            if (Directory.Exists(rootFolder))
            {
                var folderFiles = Directory.GetFiles(rootFolder);
                Track track;
                foreach (var file in folderFiles)
                {
                    if (MP3TagReader.MP3TagReader.TryCreateTagFromFile(file, out track))
                    {
                        tracks.Add(track);
                    }
                    else if (Directory.Exists(file))
                    {
                        CreateTrackList(file, tracks);
                    }
                }
            }
            return tracks;
        }

        public List<Track> UpdateTrackList(string rootFolder, List<Track> tracks)
        {
            throw new NotImplementedException();
        }
    }
}
