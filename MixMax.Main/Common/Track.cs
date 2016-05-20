using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Common
{
    public class Track
    {
        public int Id { get; set; }
        /// <summary>
        /// we can use this field to find the number of plays the user had since the last sync (by subtracting this from TotalCount
        /// </summary>
        public int LastUpdateCount { get; set; }
        public int ThreeMonthCount { get; set; }
        public int TotalCount { get; set; }        
        public bool? DoesLike { get; set; }
        public DateTime AddedOn { get; set; }
        public bool WasEverInAPlaylist { get; set; }
        public string FilePath { get; set; }
        public MediaTag Tag { get; set; }
    }
}
