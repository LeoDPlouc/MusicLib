using MusicLib.Objects;
using System.Windows.Forms;

namespace MusicLib.Control
{
    public partial class AlbumPresentation : UserControl
    {
        public AlbumPresentation() => InitializeComponent();

        public void LoadAlbum(Album album)
        {
            header.LoadAlbum(album);
            songList.Source = album.Songs;
        }
    }
}
