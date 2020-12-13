using SimpleAudioPlayer.Interfaces;
using SimpleAudioPlayer.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimpleAudioPlayer.Pages
{
   
    public partial class ListFilesPage : Page, BasePath
    {
        public GotFocusListView gotFocusListView { get; set; }

        private string basePath = "";

        public ObservableCollection<string> Mp3Files { get; set; }


        public ListFilesPage(List<string> mp3Files)
        {
            InitializeComponent();

            Mp3Files = Utils.toObservableList(mp3Files);

            if (Mp3Files.Count <= 0)
            {
                ListViewMusic.Visibility = Visibility.Collapsed;
                TextBlockEmpty.Visibility = Visibility.Visible;
            } else
            {
                ListViewMusic.DataContext = this;
            }
        }
        public int GetCurrentSelectedIndex()
        {
            return ListViewMusic.SelectedIndex;
        }
        public void SetCurrentSelectedIndex(int index)
        {
            ListViewMusic.SelectedIndex = index;
        }
        public string GetCurrentSelectedFilename()
        {
            return ListViewMusic.SelectedValue as string;
        }

        private void ListViewMusic_GotFocus(object sender, RoutedEventArgs e)
        {
            if (gotFocusListView != null)
            {
                gotFocusListView.SendFocus();
            }
        }

        public CopyFileListener CopyFileListener { set; get; }

        private void CopyMp3File_Click(object sender, RoutedEventArgs e)
        {
            if (CopyFileListener == null)
            {
                return;
            }
            string filename = GetCurrentSelectedFilename();
            if (filename == null || filename.Equals(""))
            {
                return;
            }

            CopyFileListener.CopyFile(filename);
        }

        private void DeleteMp3File_Click(object sender, RoutedEventArgs e)
        {
            if (GetCurrentSelectedIndex() < 0) return;
            
            var result = MessageBox.Show($"Вы действительно " +
                $"хотите удалить файл {GetCurrentSelectedFilename()}",
                "Удаление файла", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                string fileAbsolutePath = basePath + GetCurrentSelectedFilename();
                int selectedIndex = GetCurrentSelectedIndex();
                Task.Run(() => {
                    File.Delete(fileAbsolutePath);
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        Mp3Files.RemoveAt(selectedIndex);
                    }));
                });
            } 
            
        }

        public void SetBasePath(string path)
        {
            basePath = path + @"\";
        }

        public string GetBasePath()
        {
            return basePath;
        }
    }
}
