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
        /// Updates current list tracks with the files in rootFolder and all of its sub-folders
        /// </summary>
        /// <param name="rootFolder"></param>
        /// <param name="tracks"></param>
        /// <returns></returns>
        Dictionary<int, Track> SyncTrackList(string rootFolder, Dictionary<int, Track> tracks);
    }
}
