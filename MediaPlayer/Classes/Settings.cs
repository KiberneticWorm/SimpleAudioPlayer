using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SimpleAudioPlayer.Classes
{
    class Settings
    {
        public static string CurrentPageTitle { get; set; } = "NothingPage";
        public static string CurrentSelectedFilename { get; set; } = "";
        public static int CurrentSelectedIndex { get; set; }
        public static Page LeftPage { get; set; }
        public static Page RightPage { get; set; }
        public static string CurrentLeftPath { get; set; }
        public static string CurrentRightPath { get; set; }
    }
}
