using System;
using System.Drawing;
using System.Windows.Forms;
using MusicLib.Parts;

namespace MusicLib.Control
{
    public partial class PlayerControl : UserControl
    {
        #region Events
        public event EventHandler<PlayListButtonEventArgs> PlaylistButtonClicked;
        protected void OnPlaylistButtonClick() => PlaylistButtonClicked?.Invoke(this, new PlayListButtonEventArgs { PlaylistOn = playlist.On });
        #endregion

        public PlayerControl()
        {
            InitializeComponent();

            Player.PlayerPlayed += Player_PlayerPlayed;
            Player.ProgressChanged += PlayerControl_ProgressChanged;
        }

        private void Player_PlayerPlayed(object sender, EventArgs e) => play.ForcePlay();

        private void PlayerControl_ProgressChanged(object sender, EventArgs e)
        {
            progressBar.Value = Player.Progress * 100;
            progressBar.Invalidate();
        }

        private void ProgressBar_SliderValueChanged(object sender, EventArgs e)
        {
            Player.Progress = ((Slider)sender).Value / 100;
        }

        private void Volume_SliderValueChanged(object sender, EventArgs e)
        {
            Player.Volume = (int)((Slider)sender).Value;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Player.LoadSong(Playlist.Next());
            play.ForcePlay();
        }

        private void Playlist_Click(object sender, EventArgs e) => OnPlaylistButtonClick();


        private void Play_StateChanged(object sender, PlayButtonEventArgs e)
        {
            if (e.State == PlayButtonEventArgs.States.Play) Player.Play();
            else Player.Pause();
        }
    }

    public class PlayListButtonEventArgs : EventArgs
    {
        public bool PlaylistOn { get; set; }
    }
}
