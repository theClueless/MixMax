using MixMax.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Services.Last.fm
{
    public interface ILastFmManager
    {
        /// <summary>
        /// Tries to update track info
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        void UpdateTrackDetails(Track track);

        /// <summary>
        /// updates track's plays properties
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        void UpdateTrackPlays(Dictionary<string, Track> repository, WeeklyCharRootObject weeklyChart);

        void GetTrackChart(DateTime lastFMUpdateDate);
    }
}
