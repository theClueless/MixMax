using MixMax.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Services.DataProvider
{
    public interface IDataProvider
    {
        DataRepository Get();
        void Set(DataRepository dataRepository);
    }
}
