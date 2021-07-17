namespace MusicLib.Control
{
    partial class PlayerControl
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
            this.next = new MusicLib.Control.Next_Button();
            this.play = new MusicLib.Control.Play_Button();
            this.playlist = new MusicLib.Control.Playlist_Button();
            this.volume = new MusicLib.Control.Slider();
            this.progressBar = new MusicLib.Control.Slider();
            this.SuspendLayout();
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.Transparent;
            this.next.Location = new System.Drawing.Point(652, 18);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(32, 32);
            this.next.TabIndex = 0;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.Color.Transparent;
            this.play.Location = new System.Drawing.Point(584, 18);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(32, 32);
            this.play.TabIndex = 1;
            this.play.Text = "play_Button1";
            this.play.UseVisualStyleBackColor = false;
            this.play.StateChanged += new System.EventHandler<MusicLib.Control.PlayButtonEventArgs>(this.Play_StateChanged);
            // 
            // playlist
            // 
            this.playlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playlist.BackColor = System.Drawing.Color.Transparent;
            this.playlist.Location = new System.Drawing.Point(1158, 18);
            this.playlist.Name = "playlist";
            this.playlist.On = false;
            this.playlist.Size = new System.Drawing.Size(32, 32);
            this.playlist.TabIndex = 2;
            this.playlist.Click += new System.EventHandler(this.Playlist_Click);
            // 
            // volume
            // 
            this.volume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.volume.Location = new System.Drawing.Point(10, 26);
            this.volume.Margin = new System.Windows.Forms.Padding(0);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(100, 10);
            this.volume.TabIndex = 3;
            this.volume.Value = 75F;
            this.volume.SliderValueChanged += new System.EventHandler(this.Volume_SliderValueChanged);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1200, 8);
            this.progressBar.TabIndex = 4;
            this.progressBar.Value = 0F;
            this.progressBar.SliderValueChanged += new System.EventHandler(this.ProgressBar_SliderValueChanged);
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.playlist);
            this.Controls.Add(this.play);
            this.Controls.Add(this.next);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(1200, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private Next_Button next;
        private Play_Button play;
        private Playlist_Button playlist;
        private Slider volume;
        private Slider progressBar;
    }
}
