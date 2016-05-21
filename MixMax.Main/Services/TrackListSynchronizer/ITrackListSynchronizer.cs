using MixMax.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Services.TrackListSynchronizer
{
    public interface ITrackListSynchronizer
    {
        /// <summary>
        /// Updates current list tracks with the files in rootFolders and all of its sub-folders
        /// </summary>
        /// <param name="rootFolder"></param>
        /// <param name="tracks"></param>
        /// <returns></returns>
        Dictionary<string, Track> SyncTrackList(IEnumerable<string> rootFolders, Dictionary<string, Track> tracks);
    }
}
