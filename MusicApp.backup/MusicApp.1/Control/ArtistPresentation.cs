using MusicLib.Objects;
using System;
using System.Windows.Forms;

namespace MusicLib.Control
{
    public partial class ArtistPresentation : UserControl
    {
        #region Constants
        const int headerHeight = 200;
        #endregion

        public event EventHandler<AlbumControlEventArgs> AlbumControlClicked;
        public ArtistPresentation()
        {
            InitializeComponent();
        }

        public void LoadArtist(Artist artist)
        {
            header.LoadArtist(artist);
            albumGrid.Source = artist.Albums;
        }

        private void albumGrid_AlbumControlClicked(object sender, AlbumControlEventArgs e) => AlbumControlClicked?.Invoke(sender, new AlbumControlEventArgs { Album = e.Album });        
    }
}
