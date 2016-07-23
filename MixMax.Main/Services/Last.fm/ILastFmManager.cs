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
        /// Tries to update track's plays properties
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        void UpdateTrackPlays(Track track);
    }
}
