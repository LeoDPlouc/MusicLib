using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MusicLib.Objects;

namespace MusicLib.Control
{
    public partial class AlbumGrid : UserControl
    {
        private AlbumCollection source;
        public AlbumCollection Source
        {
            set
            {
                source = value;
                source.CollectionChanged += source_CollectionChanged;
                LoadAlbums();
            }
        }
        private string query;

        public event EventHandler<AlbumControlEventArgs> AlbumControlClicked;

        public AlbumGrid() => InitializeComponent();

        public void ChangeQuery(string query)
        {
            this.query = query;
            LoadAlbums();
        }

        private void LoadAlbums()
        {
            IEnumerable<Album> albumList = source;
            if (!string.IsNullOrEmpty(query))
            {
                albumList = source.SearchByTitle(query);
            }

            SuspendLayout();
            panel.Controls.Clear();

            foreach (Album a in albumList)
            {
                var ac = new AlbumControl();
                ac.LoadAlbum(a);
                panel.Controls.Add(ac);

                ac.DoubleClick += Ac_DoubleClick;
            }

            ResumeLayout();
        }
        private void UpdateAlbum(AlbumCollectionEventArgs.ChangeType type, Album changedAlbum)
        {
            SuspendLayout();
            System.Windows.Forms.Control[] ctrls;
            switch (type)
            {
                case AlbumCollectionEventArgs.ChangeType.Add:
                    AddAlbumControl(changedAlbum);
                    break;

                case AlbumCollectionEventArgs.ChangeType.Clear:
                    foreach (System.Windows.Forms.Control ctrl in panel.Controls)
                        CleanAlbumControls(ctrl);
                    LoadAlbums();
                    break;
                case AlbumCollectionEventArgs.ChangeType.Remove:
                    ctrls = new System.Windows.Forms.Control[panel.Controls.Count];
                    panel.Controls.CopyTo(ctrls, 0);
                    List<System.Windows.Forms.Control> controllist = new List<System.Windows.Forms.Control>(ctrls);
                    CleanAlbumControls(controllist.Find((System.Windows.Forms.Control control) =>
                    {
                        AlbumControl albumControl = control as AlbumControl;
                        return albumControl.Album == changedAlbum;
                    }));
                    break;
            }
            ResumeLayout();
        }
        private void AddAlbumControl(Album album)
        {
            var ac = new AlbumControl();
            ac.LoadAlbum(album);
            panel.Controls.Add(ac);

            ac.DoubleClick += Ac_DoubleClick;
        }
        private void CleanAlbumControls(System.Windows.Forms.Control control)
        {
            control.Dispose();
            panel.Controls.Remove(control);
        }

        delegate void UpdateAlbumsDelegate(AlbumCollectionEventArgs.ChangeType type, Album changedAlbum);
        private void source_CollectionChanged(object sender, AlbumCollectionEventArgs e) => Invoke(new UpdateAlbumsDelegate(UpdateAlbum), e.ChangeTypeArg, e.ChangedAlbum);


        private void Ac_DoubleClick(object sender, EventArgs e)
        {
            AlbumControl ac = (AlbumControl)sender;
            AlbumControlClicked?.Invoke(this, new AlbumControlEventArgs()
            {
                Album = ac.Album
            });
        }
    }

    public class AlbumControlEventArgs : EventArgs
    {
        public Album Album { get; set; }
    }
}
