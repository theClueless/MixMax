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
        private IMediaTagReader _mediaTagReader;

        public TrackListSynchronizer(IMediaTagReader mediaTagReader)
        {
            _mediaTagReader = mediaTagReader;
        }

        public Dictionary<string, Track> SyncTrackList(IEnumerable<string> rootFolders, Dictionary<string, Track> tracks)
        {
            var allFiles = GetAllFiles(rootFolders);
            tracks = SyncTrackList(allFiles, tracks);
            return tracks;
        }

        private string[] GetAllFiles(IEnumerable<string> rootFolders)
        {
            IEnumerable<string> folderFiles = new List<string>();
            foreach (var folder in rootFolders)
            {
                if (Directory.Exists(folder))
                {
                    folderFiles = folderFiles.Concat(Directory.GetFiles(folder, "*", SearchOption.AllDirectories));
                }
            }
            return folderFiles.ToArray();
        }

        private Dictionary<string, Track> SyncTrackList(string[] folderFiles, Dictionary<string, Track> tracks)
        {
            MediaTag tag;
            foreach (var file in folderFiles)
            {
                tag = _mediaTagReader.TryCreateTagFromFile(file);
                if (tag != null)
                {
                    if (tracks.ContainsKey(file))
                    {
                        tracks[file].Tag = tag;
                    }
                    else
                    {
                        Track track = CreateNewTrack(tag, file);
                        tracks.Add(track.FilePath, track);
                    }
                }
            }
            return tracks;
        }

        private Track CreateNewTrack(MediaTag tag, string file)
        {
            return new Track
            {
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
    }
}
