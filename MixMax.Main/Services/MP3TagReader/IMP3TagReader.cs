using MixMax.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Services.MP3TagReader
{
    public interface IMP3TagReader
    {
        bool TryCreateTagFromFile(string filePath, out MP3Tag tag);
    }
}
