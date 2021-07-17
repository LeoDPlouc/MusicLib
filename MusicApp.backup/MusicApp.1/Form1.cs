using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MusicLib.Control;
using MusicLib.Config;
using MusicLib.Parts;
using MusicLib.Processing;
using MusicLib.Objects;
using System.Threading;

namespace MusicLib
{
    public partial class Form1 : Form
    {
        #region Constants
        const int searchWidth = 300;
        const int tabHeight = 30;
        readonly Point middlePanelLocation = new Point(0, tabHeight);
        #endregion

        #region UI Parts
        AlbumPresentation albumPresentation;
        ArtistPresentation artistPresentation;
        ConfigControl configControl;

        TextBox search;
        #endregion

        #region Form Logic
        public Form1()
        {
            InitializeComponent();

            songlist.Source = SongCollection.GetMainCollection();
            albumGrid.Source = AlbumCollection.GetMainCollection();
            artistGrid.Source = ArtistCollection.GetMainCollection();

            Configuration.ConfigChanged += Configuration_ConfigChanged;
            InitSearch();
            Playlist.InitPlaylist();

            //Fetch all the songs
            string libraryPath = Configuration.LibraryPath;
            SongCollector.Start(libraryPath, false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => SongCollector.Stop();

        private void Configuration_ConfigChanged(object sender, ConfigEventArgs e)
        {
            if (e.Config != ConfigEventArgs.Configs.LibraryPath)
                return;

            SongCollector.Stop();
            SongCollection.GetMainCollection().Clear();
            SongCollector.Start(Configuration.LibraryPath, Configuration.ServerEnabled);
        }
        #endregion

        #region Tabs Logic

        private void ConfigTab_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            search.Text = "";

            ClearMiddlePannel();

            InitConfigControl();
            configControl.BringToFront();
            
            ResumeLayout();
        }
        private void Albumtab_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            search.Text = "";

            ClearMiddlePannel();

            albumGrid.Enabled = true;
            albumGrid.Visible = true;

            albumGrid.BringToFront();
            ResumeLayout();

            Invalidate(true);
        }
        private void Artisttab_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            search.Text = "";

            ClearMiddlePannel();

            artistGrid.Enabled = true;
            artistGrid.Visible = true;

            artistGrid.BringToFront();
            ResumeLayout();

            Invalidate(true);
        }
        private void Songtab_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            search.Text = "";

            ClearMiddlePannel();

            songlist.Enabled = true;
            songlist.Visible = true;
            songlist.BringToFront();
            ResumeLayout();

            Invalidate(true);
        }
        #endregion

        #region Search Logic
        protected void InitSearch()
        {
            search = new TextBox() { Height = tabHeight, Width = searchWidth, BackColor = Color.FromArgb(50, 50, 50) };
            Controls.Add(search);

            search.TextChanged += Search_TextChanged;
        }
        private void Search_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;

            songlist?.ChangeQuery(text);
            albumGrid?.ChangeQuery(text);
            artistGrid?.ChangeQuery(text);

            Invalidate();
        }
        #endregion

        #region Player Logic
        private void playerControl_PlaylistButtonClicked(object sender, PlayListButtonEventArgs e)
        {
            playlistControl.Visible = e.PlaylistOn;
            Invalidate(true);
        }
        private void playerControl_Load(object sender, EventArgs e) => Player.InitPlayer();
        #endregion

        #region AlbumPresentation Logic
        protected void InitAlbumPresenttion()
        {
            ClearMiddlePannel();

            albumPresentation = new AlbumPresentation
            {
                Size = songlist.Size,
                Location = songlist.Location,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            Controls.Add(albumPresentation);

            Invalidate(true);
        }
        #endregion

        #region ArtistPresentation Logic
        protected void InitArtistPresentation()
        {
            ClearMiddlePannel();

            artistPresentation = new ArtistPresentation()
            {
                Size = songlist.Size,
                Location = songlist.Location,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            artistPresentation.AlbumControlClicked += Albumgrid_AlbumControlClicked;

            Controls.Add(artistPresentation);

            Invalidate(true);
        }
        #endregion

        #region AlbumGrid Logic
        private void Albumgrid_AlbumControlClicked(object sender, AlbumControlEventArgs e)
        {
            InitAlbumPresenttion();
            albumPresentation.LoadAlbum(e.Album);
            albumPresentation.BringToFront();
        }
        #endregion

        #region ArtistGrid Logic
        private void Artistgrid_ArtistControlClicked(object sender, ArtistControlEventArgs e)
        {
            InitArtistPresentation();
            artistPresentation.LoadArtist(e.Artist);
            artistPresentation.BringToFront();
        }
        #endregion

        #region ConfigControl Logic
        protected void InitConfigControl()
        {
            ClearMiddlePannel();
            search.Visible = false;

            configControl = new ConfigControl()
            {
                Size = songlist.Size,
                Location = songlist.Location,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            
            Controls.Add(configControl);

            Invalidate();
        }
        #endregion

        private void ClearMiddlePannel()
        {
            songlist.Enabled = false;
            songlist.Visible = false;

            artistGrid.Enabled = false;
            artistGrid.Visible = false;

            albumGrid.Enabled = false;
            artistGrid.Visible = false;

            albumPresentation?.Dispose();
            albumPresentation = null;

            configControl?.Dispose();
            configControl = null;
        }
    }
}
