﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixMax.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMax.Main.Services.MP3TagReader;

namespace MixMax.Main.Test.Services.MP3TagReader
{
    [TestClass]
    public class MP3TagReaderTest
    {
        [TestMethod]
        public void CreateTrackWithDataFromFile_StandardScenario_CreateSuccessfuly()
        {
            // Arrange
            var ID3Tag = TagLib.File.Create(@"C:\Users\Moshe\Downloads\Toxicity\01 - Prison Song - Copy.mp3");

            var mp3TagReader = new MixMax.Main.Services.MP3TagReader.MP3TagReader();
            var track = mp3TagReader.CreateTrackWithTagsFromFile(@"C:\Users\Moshe\Downloads\Toxicity\01 - Prison Song - Copy.mp3");

            // Act

            // Assert
        }
    }
}