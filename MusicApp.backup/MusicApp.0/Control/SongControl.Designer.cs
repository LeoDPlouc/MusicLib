
namespace MusicLib.Control
{
    partial class SongControl
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
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.l_like = new System.Windows.Forms.Label();
            this.l_heart = new System.Windows.Forms.Label();
            this.l_n = new System.Windows.Forms.Label();
            this.l_title = new System.Windows.Forms.Label();
            this.l_duration = new System.Windows.Forms.Label();
            this.l_artist = new System.Windows.Forms.Label();
            this.l_album = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.l_like);
            this.panel.Controls.Add(this.l_heart);
            this.panel.Controls.Add(this.l_n);
            this.panel.Controls.Add(this.l_title);
            this.panel.Controls.Add(this.l_duration);
            this.panel.Controls.Add(this.l_artist);
            this.panel.Controls.Add(this.l_album);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1200, 20);
            this.panel.TabIndex = 0;
            // 
            // l_like
            // 
            this.l_like.ForeColor = System.Drawing.Color.Purple;
            this.l_like.Location = new System.Drawing.Point(0, 0);
            this.l_like.Margin = new System.Windows.Forms.Padding(0);
            this.l_like.Name = "l_like";
            this.l_like.Size = new System.Drawing.Size(50, 20);
            this.l_like.TabIndex = 0;
            this.l_like.Text = "false";
            this.l_like.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_like.DoubleClick += new System.EventHandler(this.l_like_DoubleClick);
            // 
            // l_heart
            // 
            this.l_heart.ForeColor = System.Drawing.Color.Purple;
            this.l_heart.Location = new System.Drawing.Point(53, 0);
            this.l_heart.Name = "l_heart";
            this.l_heart.Size = new System.Drawing.Size(50, 20);
            this.l_heart.TabIndex = 1;
            this.l_heart.Text = "false";
            this.l_heart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_heart.DoubleClick += new System.EventHandler(this.l_heart_DoubleClick);
            // 
            // l_n
            // 
            this.l_n.ForeColor = System.Drawing.Color.Purple;
            this.l_n.Location = new System.Drawing.Point(109, 0);
            this.l_n.Name = "l_n";
            this.l_n.Size = new System.Drawing.Size(30, 20);
            this.l_n.TabIndex = 2;
            this.l_n.Text = "00";
            this.l_n.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_n.DoubleClick += new System.EventHandler(this.SongControl_DoubleClick);
            // 
            // l_title
            // 
            this.l_title.ForeColor = System.Drawing.Color.Purple;
            this.l_title.Location = new System.Drawing.Point(145, 0);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(450, 20);
            this.l_title.TabIndex = 3;
            this.l_title.Text = "song\'s title";
            this.l_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_title.DoubleClick += new System.EventHandler(this.SongControl_DoubleClick);
            // 
            // l_duration
            // 
            this.l_duration.ForeColor = System.Drawing.Color.Purple;
            this.l_duration.Location = new System.Drawing.Point(601, 0);
            this.l_duration.Name = "l_duration";
            this.l_duration.Size = new System.Drawing.Size(40, 20);
            this.l_duration.TabIndex = 4;
            this.l_duration.Text = "00";
            this.l_duration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_duration.DoubleClick += new System.EventHandler(this.SongControl_DoubleClick);
            // 
            // l_artist
            // 
            this.l_artist.ForeColor = System.Drawing.Color.Purple;
            this.l_artist.Location = new System.Drawing.Point(647, 0);
            this.l_artist.Name = "l_artist";
            this.l_artist.Size = new System.Drawing.Size(200, 20);
            this.l_artist.TabIndex = 5;
            this.l_artist.Text = "artist\'s name";
            this.l_artist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_artist.DoubleClick += new System.EventHandler(this.SongControl_DoubleClick);
            // 
            // l_album
            // 
            this.l_album.ForeColor = System.Drawing.Color.Purple;
            this.l_album.Location = new System.Drawing.Point(853, 0);
            this.l_album.Name = "l_album";
            this.l_album.Size = new System.Drawing.Size(340, 20);
            this.l_album.TabIndex = 6;
            this.l_album.Text = "album\'s title";
            this.l_album.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_album.DoubleClick += new System.EventHandler(this.SongControl_DoubleClick);
            // 
            // SongControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel);
            this.Name = "SongControl";
            this.Size = new System.Drawing.Size(1200, 20);
            this.DoubleClick += new System.EventHandler(this.SongControl_DoubleClick);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.Label l_like;
        private System.Windows.Forms.Label l_heart;
        private System.Windows.Forms.Label l_n;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label l_duration;
        private System.Windows.Forms.Label l_artist;
        private System.Windows.Forms.Label l_album;
    }
}
