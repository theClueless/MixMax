using MixMax.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Services.MPThreeTagReader
{
    public interface IMP3TagReader
    {
        MP3Tag TryCreateTagFromFile(string filePath);
    }
}
