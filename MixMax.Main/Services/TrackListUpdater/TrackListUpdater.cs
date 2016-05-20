using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMax.Main.Common;
using System.IO;
using MixMax.Main.Services.MPThreeTagReader;

namespace MixMax.Main.Services.TrackListSynchronizer
{
    public class TrackListSynchronizer : ITrackListSynchronizer
    {
        private int _idCoutner;

        public TrackListSynchronizer()
        {
            _idCoutner = 1;
        }

        public List<Track> CreateTrackList(string rootFolder, Dictionary<int, Track> tracks)
        {
            Dictionary<string, Track> resTracks = ConvertDictFromIdToFilePath(tracks);
            if (Directory.Exists(rootFolder))
            {
                IMP3TagReader mp3TagReader = new MP3TagReader();
                var folderFiles = Directory.GetFiles(rootFolder);
                MP3Tag tag;
                foreach (var file in folderFiles)
                {
                    tag = mp3TagReader.TryCreateTagFromFile(file);
                    if (tag != null)
                    {
                        Track track = new Track
                        {
                            Id = _idCoutner++,                            
                            AddedOn = DateTime.Today,
                            FilePath = file,
                            Tag = tag,
                            WasEverInAPlaylist = false,
                            ThreeMonthCount = 0,
                            TotalCount = 0,
                            LastUpdateCount = 0,
                            DoesLike = null,
                        };
                        tracks.Add(track.Id, track);
                    }
                    else if (Directory.Exists(file))
                    {
                        CreateTrackList(file, tracks);
                    }
                }
            }
            return tracks;
        }

        private Dictionary<string, Track> ConvertDictFromIdToFilePath(Dictionary<int, Track> tracks)
        {
            Dictionary<string, Track> res = new Dictionary<string, Track>();
            foreach (var track in tracks)
            {
                res.Add(track.Value.FilePath, track.Value);
            }
            return res;
        }

        public List<Track> SyncTrackList(string rootFolder, List<Track> tracks)
        {
            throw new NotImplementedException();
        }
    }
}
