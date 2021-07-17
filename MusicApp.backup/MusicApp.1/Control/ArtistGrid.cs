using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using MusicLib.Objects;

namespace MusicLib.Control
{
    public partial class ArtistGrid : UserControl
    {
        private ArtistCollection source;
        public ArtistCollection Source
        {
            set
            {
                source = value;
                source.CollectionChanged += source_CollectionChanged;
                LoadArtists();
            }
        }
        private string query;

        public ArtistGrid() => InitializeComponent();

        public void ChangeQuery(string query)
        {
            this.query = query;
            LoadArtists();
        }
        private void LoadArtists()
        {
            IEnumerable<Artist> artistList = source;
            if (!string.IsNullOrEmpty(query))
            {
                artistList = source.SearchByName(query);
            }

            SuspendLayout();
            panel.Controls.Clear();

            foreach (Artist a in artistList)
                AddArtistControl(a);

            ResumeLayout();
        }
        private void UpdateArtist(ArtistCollectionEventArgs.ChangeType type, Artist changedArtist)
        {
            SuspendLayout();
            switch (type)
            {
                case ArtistCollectionEventArgs.ChangeType.Add:
                    AddArtistControl(changedArtist);
                    break;

                case ArtistCollectionEventArgs.ChangeType.Clear:
                    foreach (System.Windows.Forms.Control ctrl in panel.Controls)
                        CleanArtistControls(ctrl);
                    LoadArtists();
                    break;
                case ArtistCollectionEventArgs.ChangeType.Remove:
                    System.Windows.Forms.Control[] ctrls = new System.Windows.Forms.Control[panel.Controls.Count];
                    panel.Controls.CopyTo(ctrls, 0);
                    List<System.Windows.Forms.Control> controllist = new List<System.Windows.Forms.Control>(ctrls);
                    CleanArtistControls(controllist.Find((System.Windows.Forms.Control control) =>
                    {
                        ArtistControl artistControl = control as ArtistControl;
                        return artistControl.Artist == changedArtist;
                    }));
                    break;
            }
            ResumeLayout();
        }
        private void AddArtistControl(Artist artist)
        {
            var ac = new ArtistControl();
            ac.LoadArtist(artist);
            panel.Controls.Add(ac);

            ac.DoubleClick += Ac_DoubleClick;
        }
        private void CleanArtistControls(System.Windows.Forms.Control control)
        {
            control.Dispose();
            panel.Controls.Remove(control);
        }

        delegate void UpdateArtistsDelegate(ArtistCollectionEventArgs.ChangeType type, Artist changedArtist);
        private void source_CollectionChanged(object sender, ArtistCollectionEventArgs e) => Invoke(new UpdateArtistsDelegate(UpdateArtist), e.ChangeTypeArg, e.ChangedArtist);


        #region Event Handlers
        public event EventHandler<ArtistControlEventArgs> ArtistControlClicked;
        #endregion

        private void Ac_DoubleClick(object sender, EventArgs e)
        {
            ArtistControl ac = (ArtistControl)sender;
            ArtistControlClicked?.Invoke(this, new ArtistControlEventArgs()
            {
                Artist = ac.Artist
            });
        }
    }
    public class ArtistControlEventArgs : EventArgs
    {
        public Artist Artist { get; set; }
    }
}
