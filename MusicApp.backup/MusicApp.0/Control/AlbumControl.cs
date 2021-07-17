using MusicLib.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicLib.Control
{
    public partial class AlbumControl : UserControl
    {
        public Album Album { get; private set; }

        public AlbumControl() => InitializeComponent();

        public void LoadAlbum(Album album)
        {
            Album = album;

            try
            {
                using (MemoryStream s = new MemoryStream(Album.Cover))
                {
                    cover.Image = Image.FromStream(s, true, true);
                }
            }
            catch { }

            albumName.Text = album.Title;
            artistName.Text = album.Artist;
        }

        private void cover_Click(object sender, EventArgs e) => OnDoubleClick(new EventArgs());
    }
}
