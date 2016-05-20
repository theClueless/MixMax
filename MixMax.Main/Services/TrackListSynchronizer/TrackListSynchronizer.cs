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
        private int _maxIdCoutner;

        public Dictionary<int,Track> SyncTrackList(string rootFolder, Dictionary<int, Track> tracks)
        {
            Dictionary<string, Track> syncedTrackList = ConvertDictFromIdToFilePathAndSetMaxCounter(tracks);           
            if (Directory.Exists(rootFolder))
            {
                IMediaTagReader mp3TagReader = new MediaTagReader();
                var folderFiles = Directory.GetFiles(rootFolder, "*", SearchOption.AllDirectories);
                MediaTag tag;
                foreach (var file in folderFiles)
                {
                    tag = mp3TagReader.TryCreateTagFromFile(file);
                    if (tag != null)
                    {
                        if (syncedTrackList.ContainsKey(file))
                        {
                            syncedTrackList[file].Tag = tag;
                        }
                        else
                        {
                            Track track = CreateNewTrack(tag, file);
                            syncedTrackList.Add(track.FilePath, track);
                        }
                    }
                    else if (Directory.Exists(file))
                    {
                        SyncTrackList(file, tracks);
                    }
                }
            }
            return ConvertDictKeyFromPathToId(syncedTrackList);
        }

        private Track CreateNewTrack(MediaTag tag, string file)
        {
            return new Track
            {
                Id = _maxIdCoutner++,
                AddedOn = DateTime.Today,
                FilePath = file,
                Tag = tag,
                WasEverInAPlaylist = false,
                ThreeMonthCount = 0,
                TotalCount = 0,
                LastUpdateCount = 0,
                DoesLike = null,
            };
        }

        private Dictionary<string, Track> ConvertDictFromIdToFilePathAndSetMaxCounter(Dictionary<int, Track> tracks)
        {
            int maxCounterId = 0;
            Dictionary<string, Track> res = new Dictionary<string, Track>();
            foreach (var track in tracks)
            {
                maxCounterId = track.Key > maxCounterId ? track.Key : maxCounterId;
                res.Add(track.Value.FilePath, track.Value);
            }
            maxCounterId++;
            _maxIdCoutner = maxCounterId;
            return res;
        }

        private Dictionary<int, Track> ConvertDictKeyFromPathToId(Dictionary<string, Track> tracks)
        {
            Dictionary<int, Track> res = new Dictionary<int, Track>();
            foreach (var track in tracks)
            {
                res.Add(track.Value.Id, track.Value);
            }
            return res;
        }
    }
}
