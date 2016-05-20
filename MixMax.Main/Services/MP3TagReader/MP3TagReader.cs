using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMax.Main.Common;
using System.IO;

namespace MixMax.Main.Services.MPThreeTagReader
{
    public class MP3TagReader : IMP3TagReader
    {
        public MP3Tag TryCreateTagFromFile(string filePath)
        {
            MP3Tag tag = null;
            try
            {
                var ID3Tag = TagLib.File.Create(filePath);
                if (ID3Tag is TagLib.Mpeg.AudioFile)
                {
                    FillTagData(tag, ID3Tag);
                }                    
            }
            catch
            {
            }
            return tag;
        }

        private static void FillTagData(MP3Tag mpTag, TagLib.File ID3Tag)
        {
            if (ID3Tag.Tag != null)
            {
                mpTag.Name = ID3Tag.Tag.Title ?? null;
                mpTag.Album = ID3Tag.Tag.Album ?? null;
                mpTag.Artist = ID3Tag.Tag.FirstPerformer ?? null;
            }
        }
    }
}
