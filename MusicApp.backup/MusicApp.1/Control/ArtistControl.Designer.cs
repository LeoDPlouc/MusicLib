﻿
namespace MusicLib.Control
{
    partial class ArtistControl
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
            this.cover = new System.Windows.Forms.PictureBox();
            this.artistName = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cover);
            this.panel.Controls.Add(this.artistName);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(200, 250);
            this.panel.TabIndex = 0;
            // 
            // cover
            // 
            this.cover.Location = new System.Drawing.Point(0, 0);
            this.cover.Margin = new System.Windows.Forms.Padding(0);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(200, 200);
            this.cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cover.TabIndex = 0;
            this.cover.TabStop = false;
            this.cover.DoubleClick += new System.EventHandler(this.cover_DoubleClick);
            // 
            // artistName
            // 
            this.artistName.ForeColor = System.Drawing.Color.Purple;
            this.artistName.Location = new System.Drawing.Point(3, 200);
            this.artistName.Name = "artistName";
            this.artistName.Size = new System.Drawing.Size(200, 50);
            this.artistName.TabIndex = 1;
            this.artistName.Text = "artist\'s name";
            this.artistName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.artistName.DoubleClick += new System.EventHandler(this.cover_DoubleClick);
            // 
            // ArtistControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "ArtistControl";
            this.Size = new System.Drawing.Size(200, 250);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.PictureBox cover;
        private System.Windows.Forms.Label artistName;
    }
}
