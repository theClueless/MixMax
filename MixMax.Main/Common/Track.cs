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
        public int LastUpdateCount { get; set; }
        public int ThreeMonthCount { get; set; }
        public int TotalCount { get; set; }        
        public bool DoesLike { get; set; }
        public DateTime AddedOn { get; set; }
        public bool WasEverInAPlaylist { get; set; }
        public string FilePath { get; set; }
    }
}
