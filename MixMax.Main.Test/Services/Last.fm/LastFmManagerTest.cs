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
            manager.UpdateTrackDetails(track);

            // Act

            // Assert
            Assert.IsFalse(true);
        }
    }
}
