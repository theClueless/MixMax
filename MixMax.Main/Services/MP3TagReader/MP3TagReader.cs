using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMax.Main.Common;
using System.IO;

namespace MixMax.Main.Services.MP3TagReader
{
    public class MP3TagReader : IMP3TagReader
    {
        public bool TryCreateTagFromFile(string filePath, out MP3Tag tag)
        {
            tag = null;
            try
            {
                var ID3Tag = TagLib.File.Create(filePath);
                if (ID3Tag is TagLib.Mpeg.AudioFile)
                {
                    FillTagData(tag, ID3Tag);
                    return true;
                }                    
                return false;
            }
            catch 
            {
                return false;
            }
        }

        private static void FillTagData(MP3Tag mpTag, TagLib.File ID3Tag)
        {
            if (ID3Tag.Tag != null)
            {
                mpTag.Name = ID3Tag.Tag.Title ?? string.Empty;
                mpTag.Album = ID3Tag.Tag.Album ?? string.Empty;
                mpTag.Artist = ID3Tag.Tag.FirstPerformer ?? string.Empty;
            }
        }
    }

    public class MockMp3Reader : IMP3TagReader
    {

    }
}
