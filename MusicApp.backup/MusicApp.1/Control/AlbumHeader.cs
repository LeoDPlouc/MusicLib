using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MusicLib.Objects;

namespace MusicLib.Control
{
    public partial class AlbumHeader : UserControl
    {
        Album Album { get; set; }

        public AlbumHeader()
        {
            InitializeComponent();
        }

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

            albumName.Text = Album.Title;
            artistName.Text = Album.Artist;
        }

        /*private void Init()
        {
            albumName.ContextMenuStrip = new ContextMenuStrip();
            albumName.ContextMenuStrip.Items.Add("Edit");
            albumName.ContextMenuStrip.ItemClicked += ContextMenuStrip_ItemClicked;
        }

        private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Edit")
            {
                Label newTitleLabel = new Label() { Text = "New Album Title", AutoSize = true, Margin = new Padding(0, 6, 0, 0) };
                TextBox NewTitle = new TextBox() { Width = 100 };

                FlowLayoutPanel panel = new FlowLayoutPanel() { FlowDirection = FlowDirection.LeftToRight };
                panel.Controls.Add(newTitleLabel);
                panel.Controls.Add(NewTitle);

                Form form = new Form() { Size = new Size(210, 65) };
                form.Controls.Add(panel);

                form.ShowDialog();

                AlbumName.Text = NewTitle.Text;
                Album.Title = AlbumName.Text;

                Album.Save();
            }
        }*/

        protected override void OnPaint(PaintEventArgs e)
        {
            cover.Location = new Point(0, 0);
            cover.Size = new Size(Height, Height);

            albumName.Location = new Point(Height, 0);
            artistName.Location = new Point(Height, albumName.Height);
        }
    }
}
