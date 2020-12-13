using SimpleAudioPlayer.Interfaces;
using SimpleAudioPlayer.Classes;
using SimpleAudioPlayer.Pages;

namespace SimpleAudioPlayer.Classes
{
    class GotFocusListViewImpl : GotFocusListView
    {
        private string partName;
        public GotFocusListViewImpl(string partName)
        {
            this.partName = partName;
        }


        public void SendFocus()
        {
            Settings.CurrentPageTitle = partName;
        }
    }
}
