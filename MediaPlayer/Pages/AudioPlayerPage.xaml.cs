
using SimpleAudioPlayer.Classes;
using SimpleAudioPlayer.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimpleAudioPlayer.Pages
{

    public partial class AudioPlayerPage : Page
    {
        private DispatcherTimer timer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(0.1)
        };

        public AudioPlayerPage()
        {
            InitializeComponent();

            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TextBlockTime.Text = MediaElementAudioPlayer.Position.ToString(@"mm\:ss");
            if (!IsValueChanged)
            {
                SliderAudioPlayer.Value = MediaElementAudioPlayer.Position.TotalSeconds;
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            ListFilesPage lstFilesPage = null;

            if (Settings.CurrentPageTitle.Equals("LeftPage") &&
                !Utils.IsCurrentMusic())
            {
                lstFilesPage = Settings.LeftPage as ListFilesPage;
            }

            if (Settings.CurrentPageTitle.Equals("RightPage") &&
                !Utils.IsCurrentMusic())
            {
                lstFilesPage = Settings.RightPage as ListFilesPage;
            }

            if (lstFilesPage != null)
            {

                MediaElementAudioPlayer.Source = new Uri(
                    lstFilesPage.GetBasePath() + lstFilesPage.GetCurrentSelectedFilename());

                Settings.CurrentSelectedFilename =
                    lstFilesPage.GetCurrentSelectedFilename();
                Settings.CurrentSelectedIndex =
                    lstFilesPage.GetCurrentSelectedIndex();
            }

            MediaElementAudioPlayer.Play();
            timer.Start();
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            MediaElementAudioPlayer.Stop();
            timer.Stop();
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            MediaElementAudioPlayer.Pause();
            timer.Stop();
        }

        private void MediaElementAudioPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            SliderAudioPlayer.Maximum = MediaElementAudioPlayer.NaturalDuration
                .TimeSpan.TotalSeconds;
        }

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaElementAudioPlayer != null)
            {
                MediaElementAudioPlayer.Volume = SliderVolume.Value / 10.0;
            }
        }

        bool IsValueChanged = false;
        bool IsMouseCapture = false;


        private void SliderAudioPlayer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsMouseCapture)
            {
                IsValueChanged = true;
            }
        }

        private void SliderAudioPlayer_LostMouseCapture(object sender, MouseEventArgs e)
        {
            MediaElementAudioPlayer.Pause();
            MediaElementAudioPlayer.Position = TimeSpan.FromSeconds(SliderAudioPlayer.Value);
            MediaElementAudioPlayer.Play();
            IsValueChanged = false;
            IsMouseCapture = false;
            
        }

        private void SliderAudioPlayer_GotMouseCapture(object sender, MouseEventArgs e)
        {
            IsMouseCapture = true;
        }
    }
}
