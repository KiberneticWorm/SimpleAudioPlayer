using SimpleAudioPlayer.Enums;
using SimpleAudioPlayer.Interfaces;
using System;
using System.Windows;
using System.Windows.Threading;

namespace SimpleAudioPlayer.Classes
{
 

    class AudioPlayer
    {
        private DispatcherTimer timer = new DispatcherTimer()
        {
            Interval = new TimeSpan(200)
        };

        public bool IgnoreChange { get; set; } = true;

        public TimeSpan Position
        {
            get { return player.Position; }
            set { player.Position = value; }
        }

        private System.Windows.Media.MediaPlayer player;
        private AudioState currState;

        public AudioPlayer()
        {
            player = new System.Windows.Media.MediaPlayer();
            currState = AudioState.STOPPED;
            timer.Tick += Timer_Tick;
            timer.Start();      
        }

        public UpdateSliderListener SliderListener
        {
            get; set;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            IgnoreChange = true;
            if (SliderListener != null)
               {
                SliderListener.UpdateSliderValue(player.Position.TotalSeconds);
            }
            IgnoreChange = false;
        }

        public void OpenMp3File(string filePath)
        {
            player.Open(new Uri(filePath));
            currState = AudioState.OPENED;
        }

        public void Start()
        {
            player.Play();
            currState = AudioState.STARTED;
        }

        public void Stop()
        {
            player.Stop();
            currState = AudioState.STOPPED;
        }

        public void Pause()
        {
            player.Pause();

            currState = AudioState.PAUSED;
        }

        public AudioState GetCurrentState()
        {
            return currState;
        }

        public int GetProgress()
        {
            var currentPos = player.Position.TotalMilliseconds;
            var maxPos = player.NaturalDuration.TimeSpan.TotalMilliseconds;
            return (int) (currentPos / maxPos) * 100;
        }

        public void SetCurrentValue(double value)
        {
            player.Position = new TimeSpan(0, 0, (int) value);
        }

        public double CurrentValue
        {
            get { return player.Position.Seconds; }
        }

        public double GetMaximumValue()
        {
            return player.Position.TotalSeconds;
        }
    }
}
