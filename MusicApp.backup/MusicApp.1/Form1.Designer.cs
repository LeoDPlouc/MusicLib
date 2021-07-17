using MusicLib.Control;

namespace MusicLib
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.songTab = new System.Windows.Forms.Label();
            this.albumTab = new System.Windows.Forms.Label();
            this.artistTab = new System.Windows.Forms.Label();
            this.configTab = new System.Windows.Forms.Label();
            this.songlist = new MusicLib.Control.SongList();
            this.playerControl = new MusicLib.Control.PlayerControl();
            this.artistGrid = new MusicLib.Control.ArtistGrid();
            this.playlistControl = new MusicLib.Control.PlaylistControl();
            this.albumGrid = new MusicLib.Control.AlbumGrid();
            this.tabPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.songTab);
            this.tabPanel.Controls.Add(this.albumTab);
            this.tabPanel.Controls.Add(this.artistTab);
            this.tabPanel.Controls.Add(this.configTab);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(1179, 30);
            this.tabPanel.TabIndex = 0;
            // 
            // songTab
            // 
            this.songTab.ForeColor = System.Drawing.Color.Purple;
            this.songTab.Location = new System.Drawing.Point(3, 0);
            this.songTab.Name = "songTab";
            this.songTab.Size = new System.Drawing.Size(70, 30);
            this.songTab.TabIndex = 0;
            this.songTab.Text = "Song";
            this.songTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.songTab.Click += new System.EventHandler(this.Songtab_Click);
            // 
            // albumTab
            // 
            this.albumTab.ForeColor = System.Drawing.Color.Purple;
            this.albumTab.Location = new System.Drawing.Point(79, 0);
            this.albumTab.Name = "albumTab";
            this.albumTab.Size = new System.Drawing.Size(70, 30);
            this.albumTab.TabIndex = 1;
            this.albumTab.Text = "Album";
            this.albumTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.albumTab.Click += new System.EventHandler(this.Albumtab_Click);
            // 
            // artistTab
            // 
            this.artistTab.ForeColor = System.Drawing.Color.Purple;
            this.artistTab.Location = new System.Drawing.Point(155, 0);
            this.artistTab.Name = "artistTab";
            this.artistTab.Size = new System.Drawing.Size(70, 30);
            this.artistTab.TabIndex = 2;
            this.artistTab.Text = "Artist";
            this.artistTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.artistTab.Click += new System.EventHandler(this.Artisttab_Click);
            // 
            // configTab
            // 
            this.configTab.ForeColor = System.Drawing.Color.Purple;
            this.configTab.Location = new System.Drawing.Point(231, 0);
            this.configTab.Name = "configTab";
            this.configTab.Size = new System.Drawing.Size(70, 30);
            this.configTab.TabIndex = 3;
            this.configTab.Text = "Configuration";
            this.configTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.configTab.Click += new System.EventHandler(this.ConfigTab_Click);
            // 
            // songlist
            // 
            this.songlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songlist.BackColor = System.Drawing.Color.Transparent;
            this.songlist.Location = new System.Drawing.Point(0, 30);
            this.songlist.Name = "songlist";
            this.songlist.Size = new System.Drawing.Size(1179, 434);
            this.songlist.TabIndex = 2;
            // 
            // playerControl
            // 
            this.playerControl.BackColor = System.Drawing.Color.Transparent;
            this.playerControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerControl.Location = new System.Drawing.Point(0, 464);
            this.playerControl.Name = "playerControl";
            this.playerControl.Size = new System.Drawing.Size(1179, 60);
            this.playerControl.TabIndex = 1;
            this.playerControl.PlaylistButtonClicked += new System.EventHandler<PlayListButtonEventArgs>(this.playerControl_PlaylistButtonClicked);
            this.playerControl.Load += new System.EventHandler(this.playerControl_Load);
            // 
            // artistGrid
            // 
            this.artistGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.artistGrid.AutoScroll = true;
            this.artistGrid.BackColor = System.Drawing.Color.Transparent;
            this.artistGrid.Enabled = false;
            this.artistGrid.Location = new System.Drawing.Point(0, 30);
            this.artistGrid.Name = "artistGrid";
            this.artistGrid.Size = new System.Drawing.Size(1179, 434);
            this.artistGrid.TabIndex = 4;
            this.artistGrid.Visible = false;
            this.artistGrid.ArtistControlClicked += new System.EventHandler<MusicLib.Control.ArtistControlEventArgs>(this.Artistgrid_ArtistControlClicked);
            // 
            // playlistControl
            // 
            this.playlistControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistControl.Location = new System.Drawing.Point(879, 30);
            this.playlistControl.Name = "playlistControl";
            this.playlistControl.Size = new System.Drawing.Size(300, 434);
            this.playlistControl.TabIndex = 3;
            this.playlistControl.Visible = false;
            // 
            // albumGrid
            // 
            this.albumGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.albumGrid.AutoScroll = true;
            this.albumGrid.BackColor = System.Drawing.Color.Transparent;
            this.albumGrid.Enabled = false;
            this.albumGrid.Location = new System.Drawing.Point(0, 30);
            this.albumGrid.Name = "albumGrid";
            this.albumGrid.Size = new System.Drawing.Size(1179, 434);
            this.albumGrid.TabIndex = 5;
            this.albumGrid.Visible = false;
            this.albumGrid.AlbumControlClicked += new System.EventHandler<MusicLib.Control.AlbumControlEventArgs>(this.Albumgrid_AlbumControlClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1179, 524);
            this.Controls.Add(this.playlistControl);
            this.Controls.Add(this.albumGrid);
            this.Controls.Add(this.artistGrid);
            this.Controls.Add(this.songlist);
            this.Controls.Add(this.playerControl);
            this.Controls.Add(this.tabPanel);
            this.Name = "Form1";
            this.Text = "MusicApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel tabPanel;
        private System.Windows.Forms.Label songTab;
        private System.Windows.Forms.Label albumTab;
        private System.Windows.Forms.Label artistTab;
        private System.Windows.Forms.Label configTab;
        private Control.PlayerControl playerControl;
        private Control.SongList songlist;
        private Control.ArtistGrid artistGrid;
        private Control.PlaylistControl playlistControl;
        private Control.AlbumGrid albumGrid;
    }
}

