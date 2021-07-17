using System;
using System.Drawing;
using System.Windows.Forms;
using MusicLib.Parts;
using MusicLib.Objects;

namespace MusicLib.Control
{
    public partial class PlaylistControl : UserControl
    {
        #region Initialisation Logic
        /// <summary>
        /// Initiate a new instance of PlaylistControl class
        /// </summary>
        public PlaylistControl()
        {
            InitializeComponent();

            Playlist.PlaylistChanged += Playlist_PlaylistChanged;
            Playlist.SongChanged += Playlist_SongChanged;

            Player.SongAdded += Player_SongAdded;
        }
        #endregion

        #region Binding Logic
        /// <summary>
        /// Change the highlighted song when the current song changes
        /// </summary>
        private void Playlist_SongChanged(object sender, EventArgs e)
        {
            //HighlightCurrentSong();
        }
        /// <summary>
        /// Change the highlighted song when the playing song changed
        /// </summary>
        private void Player_SongAdded(object sender, EventArgs e)
        {
            //HighlightCurrentSong();
        }
        /// <summary>
        /// Reload the songlist when the playlist is changed
        /// </summary>
        private void Playlist_PlaylistChanged(object sender, EventArgs e)
        {
            songList.Source = new SongCollection(Playlist.SongList);

            //HighlightCurrentSong();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            BringToFront();
        }
        
        #region Private Functions
        /*protected void HighlightCurrentSong()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle() { BackColor = Color.FromArgb(10, 10, 10) };

            int Position = Playlist.GetPosition();
            if (Position < 0)
                return;

            //Set all the cells to the degault style
            foreach(DataGridViewRow row in Rows)
            {
                row.Cells["title"].Style = DefaultCellStyle;
                row.Cells["artist"].Style = DefaultCellStyle;
            }

            //Set the cells of the current song to the highlighting style
            Rows[Position].Cells["title"].Style = style;
            Rows[Position].Cells["artist"].Style = style;
        }*/
        #endregion
    }
}
