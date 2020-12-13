using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.Interfaces
{
    interface BasePath
    {
        void SetBasePath(string path);
        string GetBasePath();
    }
}
