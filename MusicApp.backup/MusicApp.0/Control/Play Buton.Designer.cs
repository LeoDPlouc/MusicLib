namespace MusicLib.Control
{
    partial class Play_Button
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
            this.SuspendLayout();
            // 
            // Play_Button
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.UseVisualStyleBackColor = false;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Play_Button_MouseClick);
            this.MouseEnter += new System.EventHandler(this.Play_Button_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Play_Button_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
