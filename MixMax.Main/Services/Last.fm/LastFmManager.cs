using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMax.Main.Common;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MixMax.Main.Services.Last.fm
{
    public class LastFmManager : ILastFmManager
    {
        const string LastFmBaseURL = "http://ws.audioscrobbler.com";
        const string TrackGetInfoMethod = "/2.0/?method=track.getInfo&api_key=API_KEY&artist=ARTIST_NAME&track=TRACK_NAME&format=json";
        const string UserWeeklyTrackChartMethod = "/2.0/?method=user.getweeklytrackchart&user=USER&api_key=API_KEY&from=FROMDATE&format=json";
        // should be saved in configuration
        const string APIKey = "e9d993b4899adf6855a564dc797c069f"; 
        const string UserName = "oblivion80";

        public void UpdateTrackDetails(Track track)
        {
            var urlProperties = new Dictionary<string, string>();
            urlProperties.Add("ARTIST_NAME", track.Tag.Artist);
            urlProperties.Add("TRACK_NAME", track.Tag.Name);

            string res = CreateAndSendTrackRequest(urlProperties, TrackGetInfoMethod);
            RootObject trackInfo = JsonConvert.DeserializeObject<RootObject>(res);
            if (trackInfo?.track != null)
            {
                MapResToTrack(track, trackInfo.track);
                track.MatchedOnLastFm = true;
            }
        }

        public void UpdateTrackPlays(Dictionary<string, Track> repository, WeeklyCharRootObject weeklyChart)
        {
            throw new NotImplementedException();
        }

        public void GetTrackChart(DateTime lastUpdateDate)
        {
            var urlProperties = new Dictionary<string, string>();
            urlProperties.Add("USER", UserName);
            int LastUpdateUnix = (int)(DateTime.UtcNow.Subtract(lastUpdateDate).TotalSeconds);
            urlProperties.Add("FROMDATE", LastUpdateUnix.ToString());
            string res = CreateAndSendTrackRequest(urlProperties, UserWeeklyTrackChartMethod);
            var resObject = JsonConvert.DeserializeObject<WeeklyCharRootObject>(res);
        }

        private void MapResToTrack(Track track, LastFmTrack LFmTrack)
        {
            if (LFmTrack.mbid != null)
                track.MBid = Guid.Parse(LFmTrack.mbid);

            //TO-DO: add mapping
        }

        private string CreateAndSendTrackRequest(Dictionary<string, string> urlProperties, string trackMethodName)
        {
            string res = string.Empty;
            string requestUrl = string.Format("{0}{1}", LastFmBaseURL, trackMethodName).Replace("API_KEY", APIKey);
            foreach ( var kvp in urlProperties )
            {
                requestUrl = requestUrl.Replace(kvp.Key, kvp.Value);
            }
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        res = reader.ReadToEnd();
                    }
                }
            }
            return res;
        }        
    }
}
