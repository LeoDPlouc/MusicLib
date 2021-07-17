using MusicLib.Objects;
using NAudio.Wave;
using System;
using System.Threading;

namespace MusicLib.Parts
{
    public class Player
    {
        #region Private Members
        private static WaveOutEvent outputDevice;
        private static AudioFileReader audioFile;
        private static float lastProgress;
        private static Timer t;
        #endregion

        #region Events
        public static event EventHandler SongFinished;
        public static event EventHandler ProgressChanged;
        public static event EventHandler SongAdded;
        public static event EventHandler PlayerPlayed;
        public static event EventHandler PlayerPaused;

        protected static void OnSongFinish() => SongFinished?.Invoke(null, new EventArgs());
        protected static void OnProgressChanged() => ProgressChanged?.Invoke(null, new EventArgs());
        protected static void OnSongAdded() => SongAdded?.Invoke(null, new EventArgs());
        protected static void OnPlayerPlayed() => PlayerPlayed?.Invoke(null, new EventArgs());
        protected static void OnPlayerPaused() => PlayerPaused?.Invoke(null, new EventArgs());
        #endregion

        public static void InitPlayer()
        {
            outputDevice = new WaveOutEvent();

            Playlist.SongChanged += Player_SongChanged;

            t = new Timer(_ => ProcessProgress(), null, 0, 300);
        }

        private static void ProcessProgress()
        {
            if (Progress == lastProgress)
                return;

            lastProgress = Progress;

            OnProgressChanged();

            if (Progress == 1)
                OnSongFinish();
        }

        private static void Player_SongChanged(object sender, EventArgs e)
        {
            LoadSong(Playlist.CurrentSong);
        }

        public static void LoadSong(Song song)
        {
            CurrentSong = song;
            audioFile?.Dispose();
            audioFile = new AudioFileReader(song.Path);
            outputDevice.Stop();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            OnPlayerPlayed();
        }

        public static Song CurrentSong { get; private set; }
        public static float Progress 
        {
            get
            {
                if (audioFile == null)
                    return 0;
                try
                {
                    return audioFile.Position / (float)audioFile.Length;
                }
                catch
                {
                    return 0;
                }
            }
            set 
            {
                if(audioFile != null)
                    audioFile.Position = (long)(value * audioFile.Length);
            }
        }
        public static int Volume
        {
            get => (int)outputDevice.Volume * 100;
            set => outputDevice.Volume = value / 100.0f;
        }

        public static void Play()
        {
            outputDevice.Play();
            OnPlayerPlayed();
        }
        public static void Pause()
        {
            outputDevice.Pause();
            OnPlayerPaused();
        }
    }
}
