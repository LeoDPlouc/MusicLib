namespace MusicLib.Control
{
    partial class ArtistHeader
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
            this.artistName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // artistName
            // 
            this.artistName.AutoSize = true;
            this.artistName.ForeColor = System.Drawing.Color.Purple;
            this.artistName.Location = new System.Drawing.Point(200, 0);
            this.artistName.Name = "artistName";
            this.artistName.Size = new System.Drawing.Size(65, 13);
            this.artistName.TabIndex = 0;
            this.artistName.Text = "artist\'s name";
            this.artistName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ArtistHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.artistName);
            this.Name = "ArtistHeader";
            this.Size = new System.Drawing.Size(1200, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label artistName;
    }
}
