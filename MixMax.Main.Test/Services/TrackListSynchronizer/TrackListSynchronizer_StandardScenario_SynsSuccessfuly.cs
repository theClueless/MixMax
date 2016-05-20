using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixMax.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMax.Main.Services.TrackListSynchronizer;

namespace MixMax.Main.Test.Services.TrackListSynchronizer
{
    [TestClass]
    public class TrackListSynchronizerTest
    {
        [TestMethod]
        public void TrackListSynchronizer_StandardScenario_SynsSuccessfuly()
        {
            // Arrange
            string rootFolder = @"C:\Users\Moshe\Music\mp3";
            Dictionary<int, Track> originalDict = new Dictionary<int, Track>();
            Dictionary<string, Track> resultDict = new Dictionary<string, Track>();
            MixMax.Main.Services.TrackListSynchronizer.TrackListSynchronizer syncer = new Main.Services.TrackListSynchronizer.TrackListSynchronizer();

            // Act
            originalDict = syncer.SyncTrackList(rootFolder, originalDict);

            // Assert
            int noTItle = 0; int noAlbum = 0; int noArtists = 0; int nonCompleteFiles = 0;
            foreach(var track in originalDict)
            {
                if (string.IsNullOrEmpty(track.Value.Tag.Name))
                    noTItle++;
                if (string.IsNullOrEmpty(track.Value.Tag.Album))
                    noAlbum++;
                if (string.IsNullOrEmpty(track.Value.Tag.Artist))
                    noArtists++;
                if (string.IsNullOrEmpty(track.Value.Tag.Name) || string.IsNullOrEmpty(track.Value.Tag.Album) || string.IsNullOrEmpty(track.Value.Tag.Artist))
                    nonCompleteFiles++;
            }
        }
    }
}
