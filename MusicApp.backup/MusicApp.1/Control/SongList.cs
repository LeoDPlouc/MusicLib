using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MusicLib.Config;
using MusicLib.Parts;
using MusicLib.Objects;

namespace MusicLib.Control
{
    public partial class SongList : UserControl
    {
        private SongCollection source;
        public SongCollection Source
        {
            set
            {
                source = value;
                source.CollectionChanged += Source_CollectionChanged;
                LoadSongs();
            }
        }
        private string query;

        public SongList() => InitializeComponent();
        public void ChangeQuery(string query)
        {
            this.query = query;
            LoadSongs();
        }
        private void LoadSongs()
        {
            IEnumerable<Song> songsList = source;
            if (!string.IsNullOrEmpty(query))
                songsList = source.SearchByTitle(query);

            SuspendLayout();
            foreach (Song song in songsList)
                AddSongControls(song);
            ResumeLayout();

            Invalidate(true);
        }
        private void UpdateSong(SongCollectionEventArgs.ChangeType type, Song changedSong)
        {
            SuspendLayout();
            System.Windows.Forms.Control[] ctrls;
            switch (type)
            {
                case SongCollectionEventArgs.ChangeType.Add:
                    AddSongControls(changedSong);
                    break;

                case SongCollectionEventArgs.ChangeType.Clear:
                    foreach (System.Windows.Forms.Control ctrl in panel.Controls)
                        CleanSongControls(ctrl);
                    LoadSongs();
                    break;
                case SongCollectionEventArgs.ChangeType.Remove:
                    ctrls = new System.Windows.Forms.Control[panel.Controls.Count];
                    panel.Controls.CopyTo(ctrls, 0);
                    List<System.Windows.Forms.Control> controllist = new List<System.Windows.Forms.Control>(ctrls);
                    CleanSongControls(controllist.Find((System.Windows.Forms.Control control) =>
                    {
                        SongControl songControl = control as SongControl;
                        return songControl.Song == changedSong;
                    }));
                    break;
            }
            ResumeLayout();
        }
        private void AddSongControls(Song song)
        {
            var sc = new SongControl();
            sc.LoadSong(song);
            panel.Controls.Add(sc);

            sc.SongDoubleClicked += Sc_SongDoubleClicked;
        }
        private void CleanSongControls(System.Windows.Forms.Control control)
        {
            control.Dispose();
            panel.Controls.Remove(control);
        }

        private void Sc_SongDoubleClicked(object sender, SongControlEventArgs e) => Playlist.SetCurrentSong(e.Song, source);

        delegate void UpdateSongsDelegate(SongCollectionEventArgs.ChangeType type, Song changedSong);
        private void Source_CollectionChanged(object sender, SongCollectionEventArgs e) => Invoke(new UpdateSongsDelegate(UpdateSong), e.ChangeTypeArg, e.ChangedSong);


        /*private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (CurrentCell != null) e.Cancel = false;
        }

        private async void SongList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = Rows[e.RowIndex];
            Song s = r.DataBoundItem as Song;
            await s.Save(Configuration.ServerEnabled);
        }

        private void SongList_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            CurrentCell = Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DataGridViewCell c = CurrentCell;

            if (c.ColumnIndex == Columns["HeartControl"].Index || c.ColumnIndex == Columns["Duration"].Index) return;

            if (e.ClickedItem.Text == "Edit")
            {
                BeginEdit(true);
                c.InitializeEditingControl(c.RowIndex, "", c.Style);
            }
        }*/
    }

    public class SongControlEventArgs : EventArgs
    {
        public Song Song { get; set; }
    }

    /*
     private void SongList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Columns["HeartControl"] == null) Columns.Add("HeartControl", "HeartControl");

            Columns["Path"].Visible = false;
            Columns["Heart"].Visible = false;
            Columns["Like"].Visible = false;
            Columns["AcousticId"].Visible = false;

            Columns["N"].DisplayIndex = 0;

            foreach(DataGridViewRow r in Rows)
            {
                Song s = (Song)r.DataBoundItem;
                Color sColor = s.Like ? (s.Heart ? Color.DarkRed : Color.MediumPurple) : Color.White;

                r.Cells["HeartControl"].Value = "♥";
                r.Cells["HeartControl"].Style = new DataGridViewCellStyle() { ForeColor = sColor, SelectionForeColor = sColor};
            }
        }

    private async void Song_List_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = Rows[e.RowIndex];
            Song s = (Song)row.DataBoundItem;

            if(row.Cells[e.ColumnIndex].OwningColumn.Name == "HeartControl")
            {
                if (s.Like && !s.Heart) s.Heart = true;
                else if (s.Like && s.Heart)
                {
                    s.Like = false;
                    s.Like = false;
                }
                else if (!s.Like && !s.Heart) s.Like = true;

                await s.Save(Configuration.ServerEnabled);
                SongList_DataBindingComplete(null, null);

                return;
            }

            Playlist.SetCurrentSong(s, source);
        }
     */
}
