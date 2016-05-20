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
        // Updates current list tracks with the files in rootFolder and all of its sub-folders
        List<Track> UpdateTrackList(string rootFolder, List<Track> tracks);
    }
}
