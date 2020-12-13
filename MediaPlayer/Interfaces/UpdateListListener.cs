using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.Interfaces
{
    public interface UpdateListListener
    {
        void UpdateList(string source, string filename);
    }
}
