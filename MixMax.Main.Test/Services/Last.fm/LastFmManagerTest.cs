using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixMax.Main.Common;
using MixMax.Main.Services.Last.fm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Test.Services.Last.fm
{
    [TestClass]
    public class LastFmManagerTest
    {
        [TestMethod]
        public void GetTrackInfo_StandardScenario_GetSuccessfuly()
        {
            // Arrange
            Track track = new Track
            {
                Tag = new MediaTag
                {
                    Name = "Believe",
                    Artist = "Cher",
                },
            };
            LastFmManager manager = new LastFmManager();

            // Act
            manager.UpdateTrackDetails(track);

            // Assert
            Assert.IsTrue(track.MBid != null && track.MBid == new Guid("32ca187e-ee25-4f18-b7d0-3b6713f24635"));
        }

        [TestMethod]
        public void GetWeeklyChart_StandardScenario_GetSuccessfuly()
        {
            // Arrange
            LastFmManager manager = new LastFmManager();
            DateTime lastUpdate = DateTime.Now.AddDays(-6);

            manager.GetTrackChart(lastUpdate);
            // Act
            // Assert
        }
    }
}
