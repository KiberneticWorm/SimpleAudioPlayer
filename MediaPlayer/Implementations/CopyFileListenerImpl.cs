using SimpleAudioPlayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAudioPlayer.Implementations
{
    class CopyFileListenerImpl : CopyFileListener
    {

        public string SourcePath { get; set; }
        public string DestPath { get; set; }

        public CopyFileListenerImpl(string sourcePath, string destPath)
        {
            SourcePath = sourcePath;
            DestPath = destPath;
        }

        public UpdateListListener UpdateListListener { get; set; }

        public void CopyFile(string filename)
        {
            if (SourcePath.Equals("") || DestPath.Equals(""))
            {
                return;
            }

            if (SourcePath.Equals(DestPath))
            {
                var result = MessageBox.Show("Такой файл уже существует, вы " +
                    "хотите его заменить?", "Замена файла",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result != MessageBoxResult.OK)
                {
                    return;
                }
            }
            File.Copy(SourcePath + filename, DestPath + filename, true);

            if (UpdateListListener != null)
            {
                UpdateListListener.UpdateList(SourcePath, filename);
            }
        }
    }

}
