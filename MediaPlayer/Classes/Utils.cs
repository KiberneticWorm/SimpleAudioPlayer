using SimpleAudioPlayer.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace SimpleAudioPlayer.Classes
{
    class Utils
    {
        public static string GetSelectedFolderPath()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    return dialog.SelectedPath;
                }
            }
            return "";
        }

        public static string GetBasePath(List<string> mp3Files)
        {
            if (mp3Files.Count <= 0)
            {
                return "";
            }
            return mp3Files.ElementAt(mp3Files.Count - 1);
        }

        public static bool IsCurrentMusic()
        {
            var lstFilePage = Settings.LeftPage as ListFilesPage;
            if (Settings.CurrentSelectedFilename.Equals(
                lstFilePage.GetCurrentSelectedFilename()))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static BitmapImage LoadBitmapFromResource(string pathInApplication, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }
            return new BitmapImage(new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute));
        }

        private static string GetFilename(string path)
        {
            var filename = path.Substring(path.LastIndexOf(@"\") + 1);
            if (filename.Equals(""))
            {
                return "";
            }
            string[] filenameParts = filename.Split(new char[] { '.' });
            var lenFilenameParts = filenameParts.Length;
            if (lenFilenameParts <= 0)
            {
                return "";
            }
            if (!filenameParts[lenFilenameParts - 1].Equals("mp3"))
            {
                return "";
            }
            return filename;
        }

        public static bool IsPath(string path)
        {
            return Directory.Exists(path);
        }

        public static ObservableCollection<T> toObservableList<T>(List<T> usuallyList) {
            var observableList = new ObservableCollection<T>();
            foreach (var elem in usuallyList)
            {
                observableList.Add(elem);
            }
            return observableList;
        }

        public static List<string> GetMp3FilesFromPath(string path)
        {
            List<string> mp3Files = new List<string>();

            if (path.Equals(""))
            {
                return mp3Files;
            }

            string[] files = Directory.GetFiles(path);
            
            foreach (var file in files)
            {
                string filename = GetFilename(file);
                
                if (!filename.Equals(""))
                {
                    mp3Files.Add(filename);
                }
                
            }
            return mp3Files;
        }
    }
}
