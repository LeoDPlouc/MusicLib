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
    public partial class ArtistControl : UserControl
    {
        public Artist Artist { get; private set; }

        public ArtistControl() => InitializeComponent();

        public void LoadArtist(Artist artist)
        {
            AlbumCollection albums = artist.Albums;
            Artist = artist;

            try
            {
                using (MemoryStream s = new MemoryStream(albums.First().Cover))
                {
                    cover.Image = Image.FromStream(s, true, true);
                }
            }
            catch { }
            artistName.Text = artist.Name;
        }

        private void cover_DoubleClick(object sender, EventArgs e) => OnDoubleClick(new EventArgs());
    }
}
