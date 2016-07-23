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
        const string APIKey = "e9d993b4899adf6855a564dc797c069f"; // should be saved in configuration

        public void UpdateTrackDetails(Track track)
        {
            string res = CreateAndSendTrackRequest(track, TrackGetInfoMethod);
            RootObject trackInfo = JsonConvert.DeserializeObject<RootObject>(res);
        }

        private string CreateAndSendTrackRequest(Track track, string trackMethodName)
        {
            string res = string.Empty;
            string requestUrl = string.Format("{0}{1}", LastFmBaseURL, trackMethodName).Replace("API_KEY", APIKey)
                                .Replace("ARTIST_NAME", track.Tag.Artist).Replace("TRACK_NAME", track.Tag.Name);
            //WebRequest req = WebRequest.Create(requestUrl);


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

        public void UpdateTrackPlays(Track track)
        {
            throw new NotImplementedException();
        }
    }
}
