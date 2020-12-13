using SimpleAudioPlayer.Classes;
using SimpleAudioPlayer.Implementations;
using SimpleAudioPlayer.Interfaces;
using SimpleAudioPlayer.Pages;
using System.Collections.Generic;
using System.Windows;

namespace SimpleAudioPlayer

{
    
    
    public partial class MainWindow : Window, UpdateListListener
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameAudioPlayer.NavigationService.Navigate(new AudioPlayerPage());
        }

        private void ButtonOpenSource_Click(object sender, RoutedEventArgs e)
        {
            string path = Utils.GetSelectedFolderPath();

            if (!TestPath(path)) return;

            Settings.CurrentLeftPath = path;
            TextBoxSource.Text = path;
            NavigateFromSourceTo(Utils.GetMp3FilesFromPath(path), path);
        }

        private void ButtonOpenDest_Click(object sender, RoutedEventArgs e)
        {
            string path = Utils.GetSelectedFolderPath();

            if (!TestPath(path)) return;

            Settings.CurrentRightPath = path;
            TextBoxDest.Text = path;
            NavigateFromDestTo(Utils.GetMp3FilesFromPath(path), path);
        }

        private bool TestPath(string path)
        {
            if (!Utils.IsPath(path))
            {
                MessageBox.Show("Вы указали неправильный путь",
                    "Неверный путь", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void NavigateFromSourceTo(List<string> mp3Files, string path="")
        {
            var currPage = new ListFilesPage(mp3Files);
            currPage.SetBasePath(path);
            currPage.gotFocusListView = new GotFocusListViewImpl("LeftPage");

            Settings.LeftPage = currPage;
            UpdateSourcesAndDestinations();
            FrameSource.NavigationService.Navigate(currPage);
        }

        private void NavigateFromDestTo(List<string> mp3Files, string path="")
        {
            var currPage = new ListFilesPage(mp3Files);
            currPage.SetBasePath(path);
            currPage.gotFocusListView = new GotFocusListViewImpl("RightPage");

            Settings.RightPage = currPage;
            UpdateSourcesAndDestinations();
            FrameDest.NavigationService.Navigate(currPage);
        }

        private void UpdateSourcesAndDestinations()
        {
            var leftPage = Settings.LeftPage as ListFilesPage;
            var rightPage = Settings.RightPage as ListFilesPage;

            if (leftPage == null || rightPage == null) return;

            var leftCopyFileListenerImpl = new CopyFileListenerImpl(
                    leftPage.GetBasePath(), rightPage.GetBasePath());
            leftCopyFileListenerImpl.UpdateListListener = this;
            leftPage.CopyFileListener = leftCopyFileListenerImpl;

            var rightCopyFileListenerImpl = new CopyFileListenerImpl(
                 rightPage.GetBasePath(), leftPage.GetBasePath());
            rightCopyFileListenerImpl.UpdateListListener = this;
            rightPage.CopyFileListener = rightCopyFileListenerImpl;
 
        }

        public void UpdateList(string sourcePath, string filename)
        {
            var leftPage = Settings.LeftPage as ListFilesPage;
            var rightPage = Settings.RightPage as ListFilesPage;

            if (leftPage.GetBasePath().Equals(sourcePath))
            {
                rightPage.Mp3Files.Add(filename);
            } else
            {
                leftPage.Mp3Files.Add(filename);
            }

        }
    }


}
