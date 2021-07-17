
namespace MusicLib.Control
{
    partial class AlbumPresentation
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new MusicLib.Control.AlbumHeader();
            this.songList = new MusicLib.Control.SongList();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header.BackColor = System.Drawing.Color.Transparent;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1200, 200);
            this.header.TabIndex = 0;
            // 
            // songList
            // 
            this.songList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songList.AutoScroll = true;
            this.songList.BackColor = System.Drawing.Color.Transparent;
            this.songList.Location = new System.Drawing.Point(0, 200);
            this.songList.Name = "songList";
            this.songList.Size = new System.Drawing.Size(1200, 300);
            this.songList.TabIndex = 1;
            // 
            // AlbumPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.songList);
            this.Controls.Add(this.header);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AlbumPresentation";
            this.Size = new System.Drawing.Size(1200, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private AlbumHeader header;
        private SongList songList;
    }
}
